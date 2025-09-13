using Application.Modules.AccountsModule.Commands.SignInCommand;
using Application.Repositories;
using Infrastructure.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Models.Entities.Membership;
using System.Security.Claims;

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

        [Authorize]
        [HttpGet("Login/DebugUser")]
        public IActionResult DebugUser()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value });
            return Json(claims);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signin([FromForm] SignInRequest request)
        {

            Console.WriteLine($"Signin attempt: {request.Email}");

            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                Console.WriteLine("User not found");
                return Json(new { success = false, message = "Invalid credentials" });
            }

            var passwordValid = await userManager.CheckPasswordAsync(user, request.Password);
            Console.WriteLine($"Password valid: {passwordValid}");

            var roles = await userManager.GetRolesAsync(user);
            var claims = await userManager.GetClaimsAsync(user);
            Console.WriteLine($"Roles count: {roles.Count}, Claims count: {claims.Count}");

            var claimsList = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            foreach (var role in roles)
            {
                claimsList.Add(new Claim(ClaimTypes.Role, role));
            }

            var identity = new ClaimsIdentity(claimsList, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (!passwordValid)
                return Json(new { success = false, message = "Invalid credentials" });

            try
            {
                Console.WriteLine("Attempting SignInAsync...");
                await signinManager.SignInAsync(user, isPersistent: true);
                Console.WriteLine("Signin successful");
                return Json(new { success = true, message = "Signed in successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login error: " + ex.ToString());
                Console.WriteLine("SigninAsync exception type: " + ex.GetType().FullName);
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return Json(new { success = false, message = "Unexpected server error" });
            }
        }

        [HttpPost]
        [Authorize]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Signout()
        {
            Console.WriteLine("Signout action triggered for user: " + User.Identity.Name);

            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            Response.Cookies.Delete(".AspNetCore.Cookies");

            Console.WriteLine("Signout complete, returning JSON");

            return Json(new { signedOut = true });
        }
    }
}
