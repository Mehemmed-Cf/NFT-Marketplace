using Application.Modules.CreatorsModule.Queries.CreatorGetAllQuery;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class RankingsController : Controller
    {
        private readonly ICreatorRepository creatorRepository;
        private readonly IMediator mediator;

        public RankingsController(ICreatorRepository creatorRepository, IMediator mediator)
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
    }
}
