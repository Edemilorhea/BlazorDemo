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
        Task<Book>GetBookById(int id);
        Task<ServiceResponse<Book>>AddBook(Book model);
        Task<Book>PutBook(int id, Book model);
        Task<bool>DeleteBookById(int id);
    }
}