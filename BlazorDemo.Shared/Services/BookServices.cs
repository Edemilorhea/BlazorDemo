using BlazorDemo.Shared.DBData;
using BlazorDemo.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Shared.Services;

public class BookServices : IBookServices
{
    //DI注入，負責共享實例使用，不用每次都建立新物件來使用共用的方法。
    private readonly DataContext _dataContext;

    //建構子內去建立實例
    public BookServices(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Book>> GetBooks()
    {
        var books = await _dataContext.Books.ToListAsync();
        return books;
    }

    public Task<bool> DeleteBookById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<Book>> AddBook(Book inputData)
    {
        try
        {
            _dataContext.Books.Add(inputData);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<Book> { Data = inputData };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Book>{ Success = false, Message = ex.Message };
        }
    }

    public Task<Book> PutBook(int id, Book model)
    {
        throw new NotImplementedException();
    }
}
