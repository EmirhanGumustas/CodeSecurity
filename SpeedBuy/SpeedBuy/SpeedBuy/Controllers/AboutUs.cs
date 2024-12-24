using Microsoft.AspNetCore.Mvc;

namespace SpeedBuy.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
