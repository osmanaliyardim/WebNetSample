using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Dtos;

public record SupplierDetailDto : BaseDto
{
    public SupplierDetailDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; }

    public List<ProductDetailDto> Products { get; }
}