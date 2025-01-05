using Microsoft.AspNetCore.Mvc;

namespace SpeedBuy.Controllers
{
    public class ForgetPasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
