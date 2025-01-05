using Microsoft.AspNetCore.Mvc;

namespace SpeedBuy.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
