using System.ComponentModel.DataAnnotations;
using System.Security;
using BlazorDemo.Shared.Model;
using Blazorise.Bootstrap5;
using Microsoft.AspNetCore.Components;


namespace BlazorDemo.Client.Pages;

public partial class BookCard
{
    [Parameter] [Required] public string? Id { get; set; }
    [Parameter] [Required] public string? Source { get; set; }
    [Parameter] [Required] public string? Alt { get; set; }
    [Parameter] [Required] public string? Name { get; set; }
    [Parameter] [Required] public string? Detial { get; set; }
    [Parameter] [Required] public int Price { get; set; }


    public async Task DeleteBook(){
        await BookService.DeleteBookById(Id);
        await OnRefresh.InvokeAsync();
    }

}