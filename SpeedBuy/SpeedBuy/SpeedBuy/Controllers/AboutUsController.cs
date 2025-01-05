using Microsoft.AspNetCore.Mvc;

namespace SpeedBuy.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
