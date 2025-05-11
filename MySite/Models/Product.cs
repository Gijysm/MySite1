using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace MySite.Models;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; } = null!;
    public int? Number { get; set; }
    public string? Time { get; set; }
    public string? Description { get; set; } = null!;
    public bool IsPublic { get; set; }
    public string? _image;
}