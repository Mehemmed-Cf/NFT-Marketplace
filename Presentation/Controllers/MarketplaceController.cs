using Application.Modules.CreatorsModule.Queries.CreatorGetByIdQuery;
using Application.Modules.NFTsModule.Queries.NFTGetAllQuery;
using Application.Modules.NFTsModule.Queries.NFTGetByTitleQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class MarketplaceController : Controller
    {
        private readonly IMediator mediator;

        public MarketplaceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<JsonResult> GetNfts(bool OnlyAvailable = true)
        {
            var nfts = await mediator.Send(new NFTGetAllRequest
            {
                OnlyAvailable = OnlyAvailable
            });

            var nftList = new List<object>();

            foreach(var nft in nfts)
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

        //public async Task<JsonResult> GetByTitle([FromQuery] NFTGetByTitleRequest request)
        //{
        //    var nfts = await mediator.Send(request);

        //    if(nfts == null)
        //    {
        //        return Json(new { error = "Nft not found" });
        //    }

        //    return Json(nfts);
        //}
    }
}
