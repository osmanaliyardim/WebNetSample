using WebNetSample.Entity.Concrete;

namespace WebNetSample.Business.Abstract;

public interface ICategoryService
{
    Task<List<Category>> GetListAsync();

    Task<Category> GetByIdAsync(Guid categoryId);

    Task AddAsync(Category category);

    Task UpdateAsync(Category category);
}