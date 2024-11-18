using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class RankingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
