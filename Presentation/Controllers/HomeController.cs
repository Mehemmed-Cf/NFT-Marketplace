using Application.Modules.CreatorsModule.Queries.CreatorGetAllQuery;
using Application.Modules.NFTsModule.Queries.NFTGetAllQuery;
using Application.Modules.SubscribersModule.Commands.SubscriberAddCommand;
using Application.Repositories;
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
        public async Task<JsonResult> GetNfts(bool OnlyAvailable = true)
        {
            var nfts = await mediator.Send(new NFTGetAllRequest
            {
                OnlyAvailable = OnlyAvailable
            });
            return Json(nfts);
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
