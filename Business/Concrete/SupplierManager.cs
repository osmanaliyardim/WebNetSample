using AutoMapper;
using WebNetSample.Business.Abstract;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Concrete;

public class SupplierManager : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public SupplierManager(ISupplierRepository supplierRepository,
        IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<SupplierDetailDto> GetByIdAsync(Guid productId)
    {
        var supplierInfo = await _supplierRepository.GetAsync(entity => entity.Id == productId);

        var mappedSupplier = _mapper.Map<SupplierDetailDto>(supplierInfo);

        return mappedSupplier;
    } 
        
    public async Task<List<SupplierDetailDto>> GetAllAsync()
    {
        var supplierListInfo = await _supplierRepository.GetAllAsync();

        var mappedSupplierList = _mapper.Map<List<SupplierDetailDto>>(supplierListInfo);

        return mappedSupplierList;
    }
}