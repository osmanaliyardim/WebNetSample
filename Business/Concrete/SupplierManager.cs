using WebNetSample.Business.Abstract;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.Business.Concrete;

public class SupplierManager : ISupplierService
{
    private ISupplierRepository _supplierRepository;

    public SupplierManager(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<Supplier> GetByIdAsync(Guid productId) => 
        await _supplierRepository.GetAsync(entity => entity.Id == productId);

    public async Task<List<Supplier>> GetListAsync() => await 
        _supplierRepository.GetListAsync();
}