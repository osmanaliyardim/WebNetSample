using Core.DataAccess;
using WebNetSample.Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface ISupplierDal : IEntityRepository<Supplier>
    {
    }
}