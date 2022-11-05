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
        
        builder.Property(entity => entity.Id).HasColumnName("Id");
        builder.Property(entity => entity.Name).HasColumnName("Name");
        builder.Property(entity => entity.CreationDate).HasColumnName("CreationDate");

        //  A supplier can contain more than one products.
        builder.HasMany(entity => entity.Products);
    }
}