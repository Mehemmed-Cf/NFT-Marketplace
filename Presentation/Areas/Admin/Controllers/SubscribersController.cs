using Application.Modules.SubscriberModule.Queries.SubscribersGetAllQuery;
using Application.Modules.SubscribersModule.Commands.SubscriberAddCommand;
using Application.Modules.SubscribersModule.Commands.SubscriberEditCommand;
using Application.Modules.SubscribersModule.Commands.SubscriberRemoveCommand;
using Application.Modules.SubscribersModule.Queries.SubscriberGetByIdQuery;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("admin")]
    public class SubscribersController : Controller
    {
        private readonly ISubscribersRepository subscribersRepository;
        private readonly IMediator mediator;

        public SubscribersController(ISubscribersRepository subscribersRepository, IMediator mediator)
        {
            this.subscribersRepository = subscribersRepository;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(bool OnlyAvailable = true)
        {
            var response = await mediator.Send(new SubscriberGetAllRequest
            {
                OnlyAvailable = OnlyAvailable
            });

            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] SubscriberGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SubscriberAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] SubscriberGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] SubscriberEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] SubscriberRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
