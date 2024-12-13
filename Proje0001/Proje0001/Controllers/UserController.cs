using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje0001.Contexts;
using Proje0001.Entities;

namespace Proje0001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost, Route("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
