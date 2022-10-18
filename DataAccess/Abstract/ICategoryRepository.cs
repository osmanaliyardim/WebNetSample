using WebNetSample.Core.DataAccess;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.DataAccess.Abstract;

public interface ICategoryRepository : IEntityRepository<Category>
{
}