using Microsoft.AspNetCore.Http;
using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Concrete;

public class ProductDetails : BaseEntity
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public IFormFile? ImageFile { get; set; }
    public string ImagePath { get; set; }

    public string CategoryName { get; set; }

    public string SupplierName { get; set; }

    public ProductDetails()
    {
    }

    public ProductDetails(
        Guid id, 
        string categoryName, 
        string supplierName, 
        string name,
        decimal price,
        IFormFile? imageFile,
        string imagePath) : this()
    {
        Id = id;
        CategoryName = categoryName;
        SupplierName = supplierName;
        Name = name;
        Price = price;
        ImageFile = imageFile;
        ImagePath = imagePath;
    }
}