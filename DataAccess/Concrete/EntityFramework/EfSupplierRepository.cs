using WebNetSample.Core.DataAccess.EntityFramework;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.DataAccess.Concrete.EntityFramework.Contexts;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.DataAccess.Concrete.EntityFramework;

public class EfSupplierRepository : EfEntityRepositoryBase<Supplier, WebNetSampleDBContext>, ISupplierRepository
{
    public EfSupplierRepository(WebNetSampleDBContext databaseContext) : base(databaseContext)
    {
    }
}