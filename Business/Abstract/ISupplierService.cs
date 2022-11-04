using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Abstract;

public interface ISupplierService
{
    Task<List<SupplierDetailDto>> GetAllAsync();

    Task<SupplierDetailDto> GetByIdAsync(Guid supplierId);
}