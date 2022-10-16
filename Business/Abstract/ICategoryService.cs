using WebNetSample.Entity.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        Category GetById(int categoryId);
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
        int GetCount();
    }
}