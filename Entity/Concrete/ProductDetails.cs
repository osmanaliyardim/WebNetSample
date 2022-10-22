using System;
using WebNetSample.Core.Entities;
using WebNetSample.Entity.Concrete;

namespace Entity.Concrete
{
    public class ProductDetails : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }

        public string SupplierName { get; set; }

        public ProductDetails()
        {
        }

        public ProductDetails(Guid id, string categoryName, string supplierName, string name,
            decimal price, string imageUrl) : this()
        {
            Id = id;
            CategoryName = categoryName;
            SupplierName = supplierName;
            Name = name;
            Price = price;
            ImageUrl = imageUrl;
        }
    }
}