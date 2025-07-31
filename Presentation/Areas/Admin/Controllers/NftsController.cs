using Application.Modules.NFTsModule.Commands.NFTAddCommand;
using Application.Modules.NFTsModule.Commands.NFTEditCommand;
using Application.Modules.NFTsModule.Commands.NFTRemoveCommand;
using Application.Modules.NFTsModule.Queries.NFTGetAllQuery;
using Application.Modules.NFTsModule.Queries.NFTGetByIdQuery;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NftsController : Controller
    {
        private readonly INFTRepository NFTRepository;
        private readonly ICreatorRepository creatorRepository;
        private readonly IMediator mediator;

        public NftsController(INFTRepository NFTRepository, ICreatorRepository creatorRepository, IMediator mediator)
        {
            this.NFTRepository = NFTRepository;
            this.creatorRepository = creatorRepository;
            this.mediator = mediator;
        }

        private void GetCreators()
        {
            ViewBag.Creators = creatorRepository.GetAll(m => m.DeletedAt == null);
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
            GetCreators();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NFTAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                GetCreators();
                return View(request);
            }   

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] NFTGetByIdRequest request)
        {
            GetCreators();

            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]  NFTEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                GetCreators();
                return View(request);
            }

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
