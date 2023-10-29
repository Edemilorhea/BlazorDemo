using System;
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
        var books = await _dataContext.Book.ToListAsync();
        return books;
    }

    public async Task<ServiceResponse<Book>> DeleteBookById(string id)
    {
        var response = new ServiceResponse<Book>();

        try
        {
            var book = await _dataContext.Book.FindAsync(id);            
            if(book == null){
                response.Success = false;
                response.StatusCode = 404;
                response.Message = "Book not found";
                return response;
            }
            _dataContext.Book.Remove(book);
            await _dataContext.SaveChangesAsync();
            response.Data = book;
            response.Message = "Delete Success";
        }
        catch (System.Exception ex)
        {
            response.Success = false;
            response.StatusCode = 500;
            response.Message = ex.Message;
            throw;
        }

        return response;
    }

    public async Task<ServiceResponse<Book>> GetBookById(string id)
    {
        var response = new ServiceResponse<Book>();
        try
        {
            var book = await _dataContext.Book.FindAsync(id);
            if(book == null){
                response.Success = false;
                response.StatusCode = 404;
                response.Message = "Book not found";
                return response;
            }
            response.Data = book;
            response.Message = "Get Success";
            return response;
        }
        catch (System.Exception ex)
        {
            response.Success = false;
            response.StatusCode = 500;
            response.Message = ex.Message;
            throw;
        }
    }

    public async Task<ServiceResponse<Book>> AddBook(Book inputData)
    {
        try
        {
            inputData.Id = Guid.NewGuid().ToString();
            _dataContext.Book.Add(inputData);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<Book> { Data = inputData };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ServiceResponse<Book>{ Success = false, Message = ex.Message, StatusCode = 404 };
        }
    }

    public async Task<ServiceResponse<Book>> EditBook(string id, Book inputData)
    {
        var response = new ServiceResponse<Book>();
        try{
            var book = await _dataContext.Book.FindAsync(id);
            if(book == null){
                response.Success = false;
                response.StatusCode = 404;
                response.Message = "Book not found";
                return response;
            }
            book.Name = inputData.Name;
            book.Author = inputData.Author;
            book.Publisher = inputData.Publisher;
            book.Price = inputData.Price;
            await _dataContext.SaveChangesAsync();
            response.Data = book;
            response.Message = "Edit Success";
            return response;
        }
        catch (System.Exception ex)
        {
            response.Success = false;
            response.StatusCode = 500;
            response.Message = ex.Message;
            throw;
        }
    }

    async Task<ServiceResponse<Book>> IBookServices.UploadBookCover(UploadBook model)
    {
        var response = new ServiceResponse<Book>();
        string filename = DateTime.Now.ToString("yyyyMMddHHmm") + model.FileName;
        var dbPath = Path.Combine("Upload/Books", filename);
        try
        {
            var writePath = Path.Combine("wwwroot/Upload/Books", filename);
            await File.WriteAllBytesAsync(writePath, model.Cover!);

            var book = await _dataContext.Book.FindAsync(model.Book!.Id);
            if(book == null){
                response.Success = false;
                response.StatusCode = 404;
                response.Message = "Book not found";
                return response;
            }
            book.Cover = dbPath;
            await _dataContext.SaveChangesAsync();

            response.Success = true;
            response.Message = "Upload Success";
        }
        catch (System.Exception ex)
        {
            response.Success = false;
            response.StatusCode = 500;
            response.Message = ex.Message;
            throw;
        }

        return response;
    }
}
