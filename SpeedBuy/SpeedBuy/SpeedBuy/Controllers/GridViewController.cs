using Microsoft.AspNetCore.Mvc;

namespace SpeedBuy.Controllers
{
    public class GridViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
