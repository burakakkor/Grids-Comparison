using Microsoft.AspNetCore.Mvc;

namespace Grids.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KendoUI()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
