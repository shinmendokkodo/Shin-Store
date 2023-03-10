using System.ComponentModel.DataAnnotations;

namespace Shin.Services.ProductApi.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
    [Range(0, 1000)]
    public double Price { get; set; }
}
