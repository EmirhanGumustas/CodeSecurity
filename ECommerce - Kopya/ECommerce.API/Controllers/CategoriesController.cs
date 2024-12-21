using ECommerce.Business.Abstract;
using ECommers.Shared.DataTransferObjects_DTO_;
using ECommers.Shared.Helpers;
using ECommers.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;

        public CategoriesController(ICategoryService categoryService, IBookService bookService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }

        [HttpPost,Route("AddAsyncBook")]
        public async Task<IActionResult> AddAsyncBook(BookCreateDTO bookCreateDTO)
        {
          var x =  await _bookService.AddAsync(bookCreateDTO);
            return CreateResponse(x);
        }

        [HttpPost,Route("UpdateAsyncBook")]
        public async Task<IActionResult> UpdateAsyncBook(BookUptadeDTO bookUptadeDTO)
        {
            var s = await _bookService.UpdateAsync(bookUptadeDTO);
            return Ok(s);
        }

        [HttpGet,Route("CountAsyncBook")] // dene
        public async Task<IActionResult> CountAsyncBook() // veri sayısı dönmuyor
        {
          var x =  await _bookService.CountAsync();
            return Ok(x);
        }

        [HttpGet ,Route("GetAllAsynBook")]
        public async Task<IActionResult> GetAllAsyncBook()
        {
            var y = await _bookService.GetAllAsync();
            return Ok(y);
        }

        [HttpGet, Route("DeleteAsyncBook")]
        public async Task<IActionResult> DeleteAsyncBook(int id)
        {
            var y = await _bookService.DeleteAsync(id);
            return Ok(y);
        }

        [HttpGet,Route("GetAsync")]
        public async Task<IActionResult> GetAsyncBook(int id)
        {
            var x = await _bookService.GetAsync(id);
            return Ok(x);
        }

    }
}
