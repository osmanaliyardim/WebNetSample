using System;
namespace WebNetSample.Models.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Supplier()
        {
        }

        public Supplier(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}

