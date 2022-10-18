using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Concrete;

public class Supplier : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public Supplier()
    {
    }

    public Supplier(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}