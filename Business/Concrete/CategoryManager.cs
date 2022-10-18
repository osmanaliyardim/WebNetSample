using WebNetSample.Business.Abstract;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> GetByIdAsync(Guid categoryId) => 
        await _categoryRepository.GetAsync(entity => entity.Id == categoryId);

    public async Task<List<Category>> GetListAsync() => 
        await _categoryRepository.GetListAsync();
}