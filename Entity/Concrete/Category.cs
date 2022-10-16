using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Concrete
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