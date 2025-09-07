using Application.Modules.AccountsModule.Commands.SignUpCommand;
using Application.Modules.AccountsModule.Commands.TokenRefreshCommand;
using Application.Modules.UsersModule.Commands.UserAddCommand;
using Application.Repositories;
using Infrastructure.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Models.Entities.Membership;

namespace Presentation.Controllers
{
    public class CreateAccountController : Controller
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IJwtService jwtService;
        private readonly DbContext db;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signinManager;
        private readonly IAuthenticationSchemeProvider schemeProvider;
        private readonly IUserRepository userRepository;

        public CreateAccountController(IMediator mediator, IConfiguration configuration, IJwtService jwtService, DbContext db, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IAuthenticationSchemeProvider schemeProvider, IUserRepository userRepository)
        {
            this.mediator = mediator;
            this.configuration = configuration;
            this.jwtService = jwtService;
            this.db = db;
            this.userManager = userManager;
            this.signinManager = signinManager;
            this.schemeProvider = schemeProvider;
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View(new UserAddRequest());
        }

        //[HttpPost]
        //Route("account/signup")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Signup(SignUpRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var principal = await mediator.Send(request);
        //            return RedirectToAction(nameof(HomeController.Index), "Home");
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError(string.Empty, ex.Message);
        //        }
        //    }

        //    return RedirectToAction(nameof(Index));

        //    //return RedirectToAction(nameof(SignupController.Index), "SignUp");

        //    //return View(request);
        //}

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signup([FromForm] SignUpRequest request)
        {
            Console.WriteLine($"Username: '{request.Username}'");
            Console.WriteLine($"Email: '{request.Email}'");
            Console.WriteLine($"Password: '{request.Password}'");

            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                return Json(new { success = false, message = "Invalid input." });
            }

            try
            {
                var principal = await mediator.Send(request);

                // Return JSON instead of redirect
                return Json(new { success = true, emailReceived = request.Email, message = "Signup successful" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromRoute] TokenRefreshRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] UserAddRequest request) //[FromRoute]
        {
            if (string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return Json(new { succes = false, message = "Email is Required." });
            }

            await mediator.Send(request);

            return Json(new { success = true, emailReceived = request.Email, message = "User created successfully." });

            //return RedirectToAction(nameof(Index));
        }
    }
}
