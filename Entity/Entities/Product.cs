using System;
namespace WebNetSample.Models.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }

        public Product()
        {
        }

        public Product(int id, int categoryId, int supplierId, string name,
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
}

