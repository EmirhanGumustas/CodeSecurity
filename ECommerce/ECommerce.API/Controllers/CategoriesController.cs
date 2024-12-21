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
        public CategoriesController(ICategoryService categoryService,IBookService bookService) // dipendenti injection
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO) // endpoint denir // istek bulnacak Actionlara denir.
        {
            var response = await _categoryService.AddAsync(categoryCreateDTO);
            return CreateResponse<CategoryDTO>(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return CreateResponse(response);
        }
        [HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetAsync(id);
            return Ok(response);
        }

        [HttpPost, Route("GetBookCreate")]
        public async Task<IActionResult> GetBookCreate(BookCreateDTO bookCreateDTO)
        {
            var x = await _bookService.AddAsync(bookCreateDTO);
            return Ok(x);
        }
        [HttpPost,Route("UptadeBook")]
        public async Task<IActionResult> UptadeBook(BookUptadeDTO bookUptadeDTO)
        {
            var x = await _bookService.UpdateAsync(bookUptadeDTO);
            return Ok(x);
        }
    }
}
