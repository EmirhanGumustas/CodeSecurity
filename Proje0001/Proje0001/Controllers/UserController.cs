using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje0001.Contexts;
using Proje0001.Entities;

namespace Proje0001.Controllers
{
    public class UserController : Controller
    {
        AppDbContext appDbContext = new AppDbContext();

        [HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var user = await appDbContext.Users.
                                          Include(x => x.Language).
                                          Where(u => u.IsActive == 1).
                                          ToListAsync();
            return Ok(user);
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int id)
        {
            var user = appDbContext.Users
                                   .FirstOrDefault(x => x.Id == id);
            return Ok(user);
        }
        [HttpGet, Route("StartWithEmail")]
        public async Task<IActionResult> StartWithEmail() // başında a olan.
        {
            var user = await appDbContext.Users.
                                          Where(u => u.Email.StartsWith("a")).
                                          ToListAsync();
            return Ok(user);
        }
        [HttpGet, Route("EndWithDisplayName")]
        public async Task<IActionResult> EndWithDisplayName()
        {
            var user = await appDbContext.Users
                             .Where(u => u.DisplayName.EndsWith("a"))  
                             .ToListAsync();

            return Ok();
        }









        //[HttpPost("AddSampleData")] // ekleme değiştirme

        //public IActionResult Gencay()
        //{
        //    var user =

        //    return Ok();
        //}



    }
}
