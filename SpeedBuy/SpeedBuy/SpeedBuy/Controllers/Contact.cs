using Microsoft.AspNetCore.Mvc;

namespace SpeedBuy.Controllers
{
    public class Contact : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
