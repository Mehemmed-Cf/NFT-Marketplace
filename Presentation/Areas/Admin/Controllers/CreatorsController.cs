using Application.Modules.CreatorsModule.Commands.CreatorAddCommand;
using Application.Modules.CreatorsModule.Commands.CreatorEditCommand;
using Application.Modules.CreatorsModule.Commands.CreatorRemoveCommand;
using Application.Modules.CreatorsModule.Queries.CreatorGetAllQuery;
using Application.Modules.CreatorsModule.Queries.CreatorGetByIdQuery;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "SUPERADMIN" , AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("admin")]
    public class CreatorsController : Controller
    {
        private readonly ICreatorRepository creatorRepository;
        private readonly IMediator mediator;

        public CreatorsController(ICreatorRepository creatorRepository, IMediator mediator)
        {
            this.creatorRepository = creatorRepository;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(bool OnlyAvailable = true) //
        {
            var response = await mediator.Send(new CreatorGetAllRequest
            {
                OnlyAvailable = OnlyAvailable
            });
            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] CreatorGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatorAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] CreatorGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] CreatorEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] CreatorRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
