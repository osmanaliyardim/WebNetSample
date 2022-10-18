using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebNetSample.Core.Entities;

namespace DataAccess.Concrete.EntityFramework.Configuration;

public abstract class BaseEntityConfiguration<T> where T : BaseEntity
{
    protected void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(prop => prop.Id);
        
        builder.Property(prop => prop.CreationDate);
    }
}