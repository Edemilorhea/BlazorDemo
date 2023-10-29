using BlazorDemo.Shared.Model;

namespace BlazorDemo.Shared;

public class UploadBook
{
    public Book? Book { get; set; }
    public byte[]? Cover { get; set; }
    public string? FileName { get; set; }
}
