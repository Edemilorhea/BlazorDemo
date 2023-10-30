using System.Net.Http.Json;
using BlazorDemo.Shared.Model;

namespace BlazorDemo.Shared.Services;

public class ClientBookService : IBookServices
{
    private readonly HttpClient _httpClient;

    public ClientBookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<ServiceResponse<Book>> AddBook(Book model)
    {

        var result = await _httpClient
            .PostAsJsonAsync("/api/Book/AddBook", model);
        // var result = await data.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
        // if (result != null) {
        //     return result;
        // }
        return await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
    }

    public async Task<ServiceResponse<Book>> DeleteBookById(string id)
    {
        var result = await _httpClient
            .DeleteAsync($"/api/Book/DeleteBookById?id={id}");
        return await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
    }

    public async Task<ServiceResponse<Book>> EditBook(string id, Book model)
    {
        var result = await _httpClient
            .PutAsJsonAsync($"/api/Book/EditBook/{id}", model);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
    }

    public async Task<ServiceResponse<Book>> GetBookById(string id)
    {
        var result = await _httpClient
            .GetAsync($"/api/Book/GetBookById/{id}");
        return await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
    }

    public async Task<List<Book>> GetBooks()
    {
        var result = await _httpClient
            .GetAsync("/api/Book/GetBooks");
        return await result.Content.ReadFromJsonAsync<List<Book>>();
    }

    public async Task<ServiceResponse<Book>> UploadBookCover(UploadBook model)
    {
        var result = _httpClient.PostAsJsonAsync("/api/Book/UploadBookCover", model);
        return await result.Result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
    }
}

