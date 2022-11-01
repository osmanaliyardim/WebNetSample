using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Abstract;

public interface ISupplierService
{
    Task<List<SupplierDetailDto>> GetListAsync();

    Task<SupplierDetailDto> GetByIdAsync(Guid supplierId);
}