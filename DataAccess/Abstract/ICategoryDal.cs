using Core.DataAccess;
using WebNetSample.Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}