using Microsoft.AspNetCore.Mvc;

namespace SpeedBuy.Controllers
{
    public class Cart : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
