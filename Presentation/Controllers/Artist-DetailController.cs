using Application.Modules.CreatorsModule.Queries.CreatorGetByIdQuery;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class Artist_DetailController : Controller
    {
        private readonly ICreatorRepository creatorRepository;
        private readonly IMediator mediator;

        public Artist_DetailController(ICreatorRepository creatorRepository, IMediator mediator)
        {
            this.creatorRepository = creatorRepository;
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetCreator([FromQuery] CreatorGetByIdRequest request)
        {
            var creator = await mediator.Send(request);
            return Json(creator);
        }
    }
}
