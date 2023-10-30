using Amazon.Runtime.Internal.Transform;
using BlazorDemo.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [OpenApiTag("BookServices", Description = "書籍服務")]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookService;

        public BookController(IBookServices bookServices)
        {
            _bookService = bookServices;
        }

        /// <summary>
        /// 獲取所有書籍
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            // TODO: Your code here
            await Task.Yield();
            var result = await _bookService.GetBooks();

            return Ok(result);
        }

        /// <summary>
        /// 獲取指定書籍
        /// </summary>
        /// <param name="id">書本ID</param>
        /// <remarks>給予指定的書本ID獲取書本資訊。</remarks>
        /// <response code="200">書本獲取成功</response>
        /// <response code="404">書本不存在</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Book>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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