using Application.Modules.CreatorsModule.Queries.CreatorGetByIdQuery;
using Application.Modules.NFTsModule.Queries.FilterNftByCreatorIdQuery;
using Application.Modules.NFTsModule.Queries.NFTGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("Nft_Detail")]
    public class Nft_DetailController : Controller
    {
        private readonly IMediator mediator;

        public Nft_DetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetNft")]
        [AllowAnonymous]
        public async Task<JsonResult> GetNft([FromQuery] NFTGetByIdRequest request)
        {
            var nft = await mediator.Send(request);

            if(nft == null)
            {
                return Json(new { error = "Nft not found" });
            }

            var creatorRequest = new CreatorGetByIdRequest { Id = nft.CreatorId };
            var creator = await mediator.Send(creatorRequest);

            if (creator == null)
            {
                return Json(new { error = "Creator not found" });
            }

            var nftRequest = new FilterNftByCreatorIdRequest { CreatorId = nft.CreatorId };
            var othernfts = await mediator.Send(nftRequest);
            othernfts = othernfts.Where(o => o.Id != nft.Id).ToList();

            var result = new
            {
                Nft = new
                {
                    nft.Id,
                    nft.Title,
                    nft.CreatorId,
                    nft.Description,
                    nft.Price,
                    nft.HighestBid,
                    nft.ImagePath,
                    nft.MintedAt,
                    othernfts = othernfts
                },

                Creator = new
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
                }

            };

            return Json(result);
        }
    }
}
