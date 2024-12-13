using Microsoft.AspNetCore.Mvc;
using Proje0001Fronted.Models;

namespace Proje0001Fronted.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveData(User user)
        {
            user.LanguageId = 1;
            var res = await ApiRequester.SendRequestAsync("https://localhost:7213/api/User/AddUser", user);
            if (res != "exception")
            {

            }
            return RedirectToAction("Index");
        }
    }
}
