using Application.Modules.CreatorsModule.Queries.CreatorGetByIdQuery;
using Application.Modules.NFTsModule.Queries.FilterNftByCreatorIdQuery;
using Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("Artist_Detail")]
    public class Artist_DetailController : Controller
    {
        private readonly IMediator mediator;

        public Artist_DetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetCreator")]
        public async Task<JsonResult> GetCreator([FromQuery] CreatorGetByIdRequest request)
        {
            var creator = await mediator.Send(request);

            if(creator == null)
            {
                return Json(new { error = "Creator not found" });
            }

            var nftRequest = new FilterNftByCreatorIdRequest { CreatorId = request.Id };
            var nfts = await mediator.Send(nftRequest);

            var result = new
            {
                creator.Id,
                creator.ChainId,
                creator.NickName,
                creator.Email,
                creator.Bio,
                creator.Followers,
                creator.Volume,
                creator.SoldNFts,
                creator.TotalSales,
                creator.ImagePath,

                nfts = nfts


                //Nfts = nfts
            };

            return Json(result);
        }
    }
}
