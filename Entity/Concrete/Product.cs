using System.ComponentModel.DataAnnotations;
using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Concrete;

public class Product : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Guid SupplierId { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a name")]
    [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 50")]
    public string Name { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a price")]
    public decimal Price { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an Image URL")]
    [StringLength(maximumLength: 50, MinimumLength = 10, ErrorMessage = "Product Image URL must contain at least 10 characters.")]
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