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
                                          Where(u => u.Email.StartsWith("E")).
                                          ToListAsync();
            return Ok(user);
        }
        [HttpGet, Route("EndWithDisplayName")]
        public async Task<IActionResult> EndWithDisplayName()
        {
            var user = await appDbContext.Users
                             .Where(u => u.DisplayName.EndsWith("m"))
                             .ToListAsync();

            return Ok(user);
        }

        [HttpGet, Route("OrderByUserId")]
        public IActionResult OrderByUserId()
        {
            var user = appDbContext.Languages.
                                 Include(x => x.Users).
                                 Where(x => x.Id > 2 || x.IsActive == 1).
                                 OrderBy(x => x.Id);
            return Ok(user);
        }
        [HttpGet, Route("Count")]
        public IActionResult Count()
        {
            //var user =  appDbContext.Users.ToList().Count(); string yakalar
            var user = appDbContext.Users.Count();              // int yakalar

            return Ok(user);
        }
        [HttpGet, Route("Dıstınct")]
        public IActionResult Dıstınct()
        {
            var distinctUserCount = appDbContext.Users
                                    .Select(u => u.Email) // Sadece Id'leri seç
                                    .Distinct()        // Tekrarlayanları kaldır
                                    .Count();

            return Ok(distinctUserCount);
        }
        [HttpGet, Route("WhereInContain")]
        public IActionResult WhereInContain() // içinde var mı
        {
            var whereInContain = appDbContext.Users.
                                        Where(u=>u.Email.Contains("@")).
                                        ToList(); //IQUERYBAL olanlara tolist getirme zorunlulugu var

            return Ok(whereInContain);
        }







        //[HttpPost("AddSampleData")] // ekleme değiştirme

        //public IActionResult Gencay()
        //{
        //    var user =

        //    return Ok();
        //}



    }
}
