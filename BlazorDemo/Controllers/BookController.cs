using BlazorDemo.Shared;
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
        public async Task<ActionResult<ServiceResponse<Book>>> GetBookById(string id)
        {
            // TODO: Your code here
            await Task.Yield();
            var result = await _bookService.GetBookById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Book>>> AddBook(UploadBook model)
        {
            // TODO: Your code here
            await Task.Yield();
            var result = await _bookService.AddBook(model.Book!);
            await _bookService.UploadBookCover(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Book>>> EditBook(string id, Book model)
        {
            // TODO: Your code here
            await Task.Yield();
            var result = await _bookService.EditBook(id, model);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<Book>>> DeleteBookById(string id)
        {
            // TODO: Your code here
            await Task.Yield();
            var result = await _bookService.DeleteBookById(id);
            return Ok(result);
        }
    }
}