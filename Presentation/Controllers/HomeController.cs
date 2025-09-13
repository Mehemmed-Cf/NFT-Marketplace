using Application.Modules.CreatorsModule.Queries.CreatorGetAllQuery;
using Application.Modules.CreatorsModule.Queries.CreatorGetByIdQuery;
using Application.Modules.NFTsModule.Queries.NFTGetAllQuery;
using Application.Modules.SubscribersModule.Commands.SubscriberAddCommand;
using Application.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICreatorRepository creatorRepository;
        private readonly IMediator mediator;

        public HomeController(ICreatorRepository creatorRepository, IMediator mediator)
        {
            this.creatorRepository = creatorRepository;
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult IsSignedIn()
        {

            if (User.Identity.IsAuthenticated)
                return Json(new { signedIn = true, username = User.Identity.Name });

            return Json(new { signedIn = false });
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<JsonResult> GetCreators(bool OnlyAvailable = true)
        {
            var creators = await mediator.Send(new CreatorGetAllRequest
            {
                OnlyAvailable = OnlyAvailable
            });
            return Json(creators);
        }

        [AllowAnonymous]
        public async Task<JsonResult> GetRandomNfts(bool OnlyAvailable = true)
        {
            var nfts = await mediator.Send(new NFTGetAllRequest
            {
                OnlyAvailable = OnlyAvailable
            });

            var randomNfts = nfts.OrderBy(n => Guid.NewGuid()).Take(3).ToList();

            var nftList = new List<object>();

            foreach (var nft in randomNfts)
            {
                var creator = await mediator.Send(new CreatorGetByIdRequest { Id = nft.CreatorId });

                nftList.Add(new
                {
                    nft.Id,
                    nft.Title,
                    nft.Description,
                    nft.Price,
                    nft.HighestBid,
                    nft.ImagePath,
                    nft.CreatorId,
                    creator = creator
                });
            }

            return Json(new { nfts = nftList });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddSubscriber([FromForm] SubscriberAddRequest request)
        {

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return Json(new { succes = false, message = "Email is Required." });
            }

            await mediator.Send(request);

            Console.WriteLine(request.Email);

            return Json(new { success = true, email = request.Email });

            //if (request == null || string.IsNullOrWhiteSpace(request.Email))
            //{
            //    return Json(new { success = false, message = "No email received" });
            //}

            //return Json(new
            //{
            //    success = true,
            //    emailReceived = request.Email
            //});
        }
    }
}
