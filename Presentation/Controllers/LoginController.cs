using Application.Modules.AccountsModule.Commands.SignInCommand;
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
    public class LoginController : Controller
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IJwtService jwtService;
        private readonly DbContext db;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signinManager;
        private readonly IAuthenticationSchemeProvider schemeProvider;
        private readonly IUserRepository userRepository;

        public LoginController(IMediator mediator, IConfiguration configuration, IJwtService jwtService, DbContext db, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IAuthenticationSchemeProvider schemeProvider, IUserRepository userRepository)
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signin(SignInRequest request)
        {
            if (ModelState.IsValid)
            {
                var principal = await mediator.Send(request);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            TempData["LogInError"] = System.Web.HttpUtility.JavaScriptStringEncode("You are not Mentally Ill enaugh to Log");
            return RedirectToAction(nameof(LoginController.Index), "Login");
        }
    }
}
