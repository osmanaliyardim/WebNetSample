using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Abstract;

public interface ICategoryService
{
    Task<List<CategoryDetailDto>> GetAllAsync();

    Task<CategoryDetailDto> GetByIdAsync(Guid categoryId);

    Task AddAsync(CategoryDetailDto category);

    Task UpdateAsync(CategoryDetailDto category);
}