using Application.Modules.NFTsModule.Commands.NFTRemoveCommand;
using Application.Modules.UsersModule.Commands.UserAddCommand;
using Application.Modules.UsersModule.Commands.UserEditCommand;
using Application.Modules.UsersModule.Commands.UserRemoveCommand;
using Application.Modules.UsersModule.Queries.UserGetAllQuery;
using Application.Modules.UsersModule.Queries.UserGetByIdQuery;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMediator mediator;

        public UsersController(IUserRepository userRepository, IMediator mediator)
        {
            this.userRepository = userRepository;
            this.mediator = mediator;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(bool OnlyAvailable = true) // 
        {
            var response = await mediator.Send(new UserGetAllRequest
            {
                OnlyAvailable = OnlyAvailable
            });

            return View(response);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details([FromRoute] UserGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromForm] UserAddRequest request) //[FromRoute]
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Edit([FromRoute] UserGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Edit([FromForm] UserEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Remove([FromRoute] UserRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
