using System;
using System.ComponentModel.DataAnnotations;

namespace KikoStore.Api.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Range(1.0, double.MaxValue, ErrorMessage = "Value must be more than zero")]
    public decimal Price { get; set; }
    [Required]
    public string PictureUrl { get; set; } = string.Empty;
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public string Brand { get; set; } = string.Empty;
    [Range(1, int.MaxValue, ErrorMessage = "Value must be at least one")]
    public int QuantityInStock { get; set; }
}
