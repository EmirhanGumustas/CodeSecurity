using Microsoft.AspNetCore.Mvc;

namespace SpeedBuy.Controllers
{
    public class ListViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
