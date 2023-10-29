using System.Net.Mime;
using System.ComponentModel.DataAnnotations;
namespace BlazorDemo.Shared.Model;

public class Book
{
    [Key]
    public string Id { get; set; } = string.Empty;
    [Required(ErrorMessage = "請輸入書名")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "請輸入作者")]
    public string Author { get; set; } = string.Empty;
    [Required(ErrorMessage = "請輸入出版商")]
    public string Publisher { get; set; } = string.Empty;
    [Required(ErrorMessage = "請輸入價格")]
    public int Price { get; set; }
    public string? Detail { get; set; } = "尚未撰寫書籍詳細內容";
    public string? ALT { get; set; }
    public string? Cover { get; set; }
}
