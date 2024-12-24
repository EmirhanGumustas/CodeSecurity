using Microsoft.AspNetCore.Mvc;
using SpeedBuy.Models;
using System.Diagnostics;

namespace SpeedBuy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
