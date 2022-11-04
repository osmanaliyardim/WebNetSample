using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebNetSample.Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.Configuration;

public class CategoryConfiguration : BaseEntityConfiguration<Category>, IEntityTypeConfiguration<Category>
{
    public new void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable("Categories").HasKey(entity => entity.Id);
        
        builder.Property(prop => prop.Id).HasColumnName("Id");
        builder.Property(prop => prop.Name).HasColumnName("Name");
        builder.Property(prop => prop.ImagePath).HasColumnName("ImagePath");
        builder.Property(prop => prop.CreationDate).HasColumnName("CreationDate");

        // A category can contain more than one products.
        builder.HasMany(entity => entity.Products);
    }
}