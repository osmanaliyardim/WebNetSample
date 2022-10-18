using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebNetSample.Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.Configuration;

public class SupplierConfiguration : BaseEntityConfiguration<Supplier>, IEntityTypeConfiguration<Supplier>
{
    public new void Configure(EntityTypeBuilder<Supplier> builder)
    {
        base.Configure(builder);

        builder.ToTable("Suppliers").HasKey(entity => entity.Id);
        
        builder.Property(prop => prop.Id).HasColumnName("Id");
        builder.Property(prop => prop.Name).HasColumnName("Name");

        //  A supplier can contain more than one products.
        builder.HasMany(entity => entity.Products);
    }
}