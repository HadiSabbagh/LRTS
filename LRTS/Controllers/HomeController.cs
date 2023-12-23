using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance.Context;
using Persistance.Services;

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
