using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Shared.Model;

namespace BlazorDemo.Shared.Services
{
    public interface IBookServices
    {
        Task<List<Book>> GetBooks();
        Task<ServiceResponse<Book>>GetBookById(string id);
        Task<ServiceResponse<Book>>AddBook(Book model);
        Task<ServiceResponse<Book>>EditBook(string id, Book model);
        Task<ServiceResponse<Book>>DeleteBookById(string id);
        Task<ServiceResponse<Book>>UploadBookCover(UploadBook model);
    }
}