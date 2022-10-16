using Business.Abstract;
using DataAccess.Abstract;
using WebNetSample.Entity.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(x => x.Id == categoryId);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetList().ToList();
        }

        public int GetCount()
        {
            return _categoryDal.GetList().Count;
        }
    }
}