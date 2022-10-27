using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebNetSample.Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.Configuration;

public class ProductConfiguration : BaseEntityConfiguration<Product>, IEntityTypeConfiguration<Product>
{
    public new void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.ToTable("Products").HasKey(entity => entity.Id);
        builder.Property(prop => prop.Id).HasColumnName("Id");

        builder.Property(prop => prop.CategoryId).HasColumnName("CategoryId");
        builder.Property(prop => prop.SupplierId).HasColumnName("SupplierId");
        builder.Property(prop => prop.Name).HasColumnName("Name");
        builder.Property(prop => prop.Price).HasColumnName("Price");
        builder.Property(prop => prop.ImagePath).HasColumnName("ImagePath");
        builder.Property(prop => prop.CreationDate).HasColumnName("CreationDate");

        // A product can contain more than one categories and suppliers.
        builder.HasMany(prop => prop.Categories);
        builder.HasMany(prop => prop.Suppliers);
    }
}
