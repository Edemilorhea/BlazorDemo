using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookService;

        public BookController(IBookServices bookServices)
        {
            _bookService = bookServices;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            // TODO: Your code here
            await Task.Yield();
            var result = await _bookService.GetBooks();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Book>>> AddBook(Book model)
        {
            // TODO: Your code here
            await Task.Yield();
            var result = await _bookService.AddBook(model);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditBook(int id, Book model)
        {
            // TODO: Your code here
            await Task.Yield();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Book>> DeleteBookById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }
    }
}