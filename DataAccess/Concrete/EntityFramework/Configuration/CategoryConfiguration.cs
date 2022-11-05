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

        builder.Property(entity => entity.Id).HasColumnName("Id");
        builder.Property(entity => entity.Name).HasColumnName("Name");
        builder.Property(entity => entity.ImagePath).HasColumnName("ImagePath");
        builder.Property(entity => entity.CreationDate).HasColumnName("CreationDate");

        // A category can contain more than one products.
        builder.HasMany(entity => entity.Products);
    }
}