using Microsoft.AspNetCore.Mvc;

namespace LRTS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
