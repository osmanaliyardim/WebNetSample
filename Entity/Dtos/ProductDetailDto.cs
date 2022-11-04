using Microsoft.AspNetCore.Http;
using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Dtos;

public record ProductDetailDto : BaseDto
{
    public ProductDetailDto(
        string name,
        decimal price,
        string imagePath,
        string categoryname,
        string supplierName)
    {
        Name = name;
        Price = price;
        ImagePath = imagePath;
        CategoryName = categoryname;
        SupplierName = supplierName;
    }

    public string Name { get; }

    public decimal Price { get; }

    public string ImagePath { get; }

    public string CategoryName { get; }

    public string SupplierName { get; }
}