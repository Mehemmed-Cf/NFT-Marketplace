using Application.Modules.CreatorsModule.Commands.CreatorAddCommand;
using Application.Modules.CreatorsModule.Queries.CreatorGetByIdQuery;
using Application.Modules.NFTsModule.Commands.NFTAddCommand;
using Application.Modules.NFTsModule.Commands.NFTEditCommand;
using Application.Modules.NFTsModule.Commands.NFTRemoveCommand;
using Application.Modules.NFTsModule.Queries.NFTGetAllQuery;
using Application.Modules.NFTsModule.Queries.NFTGetByIdQuery;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NftsController : Controller
    {
        private readonly INFTRepository NFTRepository;
        private readonly IMediator mediator;

        public NftsController(INFTRepository NFTRepository, IMediator mediator)
        {
            this.NFTRepository = NFTRepository;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(bool OnlyAvailable = true) //
        {
            var response = await mediator.Send(new NFTGetAllRequest { 
                OnlyAvailable = OnlyAvailable 
            });

            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] NFTGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NFTAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] NFTGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]  NFTEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] NFTRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
