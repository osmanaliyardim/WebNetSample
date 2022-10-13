using System;
namespace WebNetSample.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
        }

        public Category(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}

