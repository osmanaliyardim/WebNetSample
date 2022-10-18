using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Concrete;

public class Product : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Guid SupplierId { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }

    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Supplier> Suppliers { get; set; }

    public Product()
    {
    }

    public Product(Guid id, Guid categoryId, Guid supplierId, string name,
        decimal price, string imageUrl) : this()
    {
        Id = id;
        CategoryId = categoryId;
        SupplierId = supplierId;
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
    }
}