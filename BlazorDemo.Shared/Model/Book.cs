using System.Net.Mime;
using System.ComponentModel.DataAnnotations;
namespace BlazorDemo.Shared.Model;

public class Book
{
    [Key]
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string Publisher { get; set; }
    public required int Price { get; set; }
    public string? Cover { get; set; }
}
