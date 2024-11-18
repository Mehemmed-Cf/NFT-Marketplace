using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class MarketplaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
