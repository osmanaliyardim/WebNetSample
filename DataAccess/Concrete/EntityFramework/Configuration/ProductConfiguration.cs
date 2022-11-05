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

        builder.Property(entity => entity.Id).HasColumnName("Id");
        builder.Property(entity => entity.CategoryId).HasColumnName("CategoryId");
        builder.Property(entity => entity.SupplierId).HasColumnName("SupplierId");
        builder.Property(entity => entity.Name).HasColumnName("Name");
        builder.Property(entity => entity.Price).HasColumnName("Price");
        builder.Property(entity => entity.ImagePath).HasColumnName("ImagePath");
        builder.Property(entity => entity.CreationDate).HasColumnName("CreationDate");

        // A product can contain more than one categories and suppliers.
        builder.HasMany(entity => entity.Categories);
        builder.HasMany(entity => entity.Suppliers);
    }
}
