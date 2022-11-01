using Microsoft.AspNetCore.Http;
using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Dtos;

public record ProductDetailDto : BaseDto
{
    public ProductDetailDto(
    string name,
    decimal price,
    string imageUrl,
    string categoryname,
    string supplierName)
    {
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
        CategoryName = categoryname;
        SupplierName = supplierName;
    }

    public string Name { get; }

    public decimal Price { get; }

    public string ImageUrl { get; }

    public string CategoryName { get; }

    public string SupplierName { get; }
}