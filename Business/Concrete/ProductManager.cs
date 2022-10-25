using AutoMapper;
using Core.Aspects.Logging;
using WebNetSample.Business.Abstract;
using WebNetSample.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using WebNetSample.Core.Pagination;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductManager(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public Task AddAsync(Product product) => _productRepository.AddAsync(product);

    public void Delete(Product product) => _productRepository.Delete(p => p.Id == product.Id);

    public void Update(Product product) => _productRepository.Update(product);

    public async Task<Product> GetByIdAsync(Guid productId) =>
        await _productRepository.GetAsync(entity => entity.Id == productId);

    [LogAspect(typeof(FileLogger))]
    public async Task<List<Product>> GetListAsync(PaginationParameters paginationParameters) =>
        _productRepository.GetListAsync().Result
            .Skip(paginationParameters.RecordsToSkip)
                .Take(paginationParameters.PageSize).ToList();

    public async Task<List<Product>> GetListByCategoryIdAsync(Guid categoryId) =>
        await _productRepository.GetListAsync(entity => entity.CategoryId == categoryId);

    [LogAspect(typeof(FileLogger))]
    public async Task<List<ProductDetailDto>> GetProductDetailsAsync()
    {
        var productInfo = await _productRepository.GetProductDetailsAsync();

        var productDetails = _mapper.Map<List<ProductDetailDto>>(productInfo);

        return productDetails;
    }

    public async Task<List<ProductDetailDto>> GetProductDetailsByCategoryIdAsync(Guid categoryId)
    {
        var productInfo = await _productRepository.GetProductDetailsAsync(entity => entity.CategoryId == categoryId);

        var productDetails = _mapper.Map<List<ProductDetailDto>>(productInfo);

        return productDetails;
    }

    public async Task<List<ProductDetailDto>> GetProductDetailsBySupplierIdAsync(Guid supplierId)
    {
        var productInfo = await _productRepository.GetProductDetailsAsync(entity => entity.SupplierId == supplierId);

        var productDetails = _mapper.Map<List<ProductDetailDto>>(productInfo);

        return productDetails;
    }
}