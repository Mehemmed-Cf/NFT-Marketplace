using Application.Modules.UsersModule.Commands.UserAddCommand;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CreateAccountController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMediator mediator;

        public CreateAccountController(IUserRepository userRepository, IMediator mediator)
        {
            this.userRepository = userRepository;
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new UserAddRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UserAddRequest request) //[FromRoute]
        {
            Console.WriteLine("POST Create hit!");
            Console.WriteLine($"Username: {request.Username}, Email: {request.Email}");

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
