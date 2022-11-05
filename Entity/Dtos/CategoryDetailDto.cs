using Microsoft.AspNetCore.Http;
using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Dtos;

public record CategoryDetailDto : BaseDto
{
    public CategoryDetailDto(
        Guid id,
        string name,
        string imagePath,
        IFormFile? imageFile)
    {
        Id = id;
        Name = name;
        ImagePath = imagePath;
        ImageFile = imageFile;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string ImagePath { get; }

    public IFormFile? ImageFile { get; }

    public List<ProductDetailDto> Products { get; }
}