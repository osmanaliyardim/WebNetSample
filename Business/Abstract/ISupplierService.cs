using WebNetSample.Entity.Concrete;

namespace WebNetSample.Business.Abstract;

public interface ISupplierService
{

    Task<List<Supplier>> GetListAsync();

    Task<Supplier> GetByIdAsync(Guid supplierId);

}