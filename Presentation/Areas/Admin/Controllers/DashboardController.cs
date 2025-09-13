﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "SUPERADMIN" , AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
