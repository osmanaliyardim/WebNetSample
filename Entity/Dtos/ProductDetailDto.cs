using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Dtos;

public record ProductDetailDto : BaseDto
{
    public ProductDetailDto(
        Guid id,
        string name,
        decimal price,
        string imagePath,
        string categoryname,
        string supplierName)
    {
        Id = id;
        Name = name;
        Price = price;
        ImagePath = imagePath;
        CategoryName = categoryname;
        SupplierName = supplierName;
    }

    public Guid Id { get; }

    public string Name { get; }

    public decimal Price { get; }

    public string ImagePath { get; }

    public string CategoryName { get; }

    public string SupplierName { get; }

    public List<CategoryDetailDto> Categories { get; }

    public List<SupplierDetailDto> Suppliers { get; }
}