using WebNetSample.Core.DataAccess.EntityFramework;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.DataAccess.Concrete.EntityFramework.Contexts;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.DataAccess.Concrete.EntityFramework;

public class EfCategoryRepository : EfEntityRepositoryBase<Category, WebNetSampleDBContext>, ICategoryRepository
{
    public EfCategoryRepository(WebNetSampleDBContext databaseContext) : base(databaseContext)
    {
    }
}