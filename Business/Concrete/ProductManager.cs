using AutoMapper;
using WebNetSample.Core.Aspects.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebNetSample.Business.Abstract;
using WebNetSample.Core.Aspects.Caching;
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
    private const int durationInMinutes = 30;

    public ProductManager(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    [CacheRemoveAspect("IProductService.Get")]
    public async Task AddAsync(ProductDetailDto product)
    {
        var mappedProduct = _mapper.Map<Product>(product);

        await _productRepository.AddAsync(mappedProduct);
    }
        

    [CacheRemoveAspect("IProductService.Get", Priority = 1)]
    public async Task DeleteAsync(ProductDetailDto product)
    {
        var mappedProduct = _mapper.Map<Product>(product);

        await _productRepository.DeleteAsync(p => p.Id == mappedProduct.Id);
    }


    [CacheRemoveAspect("IProductService.Get")]
    public async Task UpdateAsync(ProductDetailDto product)
    {
        var mappedProduct = _mapper.Map<Product>(product);

        await _productRepository.UpdateAsync(mappedProduct);
    }


    [CacheAspect(duration: durationInMinutes)]
    public async Task<ProductDetailDto> GetByIdAsync(Guid productId)
    {
        var product = await _productRepository.GetAsync(entity => entity.Id == productId);

        var mappedProduct = _mapper.Map<ProductDetailDto>(product);

        return mappedProduct;
    }
        

    [LogAspect(typeof(FileLogger))]
    [CacheAspect(duration: durationInMinutes)]
    public async Task<List<ProductDetailDto>> GetAllAsync(PaginationParameters paginationParameters)
    {
        var products = _productRepository.GetAllAsync().Result
            .Skip(paginationParameters.RecordsToSkip)
                .Take(paginationParameters.PageSize).ToList();

        var mappedProducts = _mapper.Map<List<ProductDetailDto>>(products);

        return mappedProducts;
    }
        

    public async Task<List<ProductDetailDto>> GetListByCategoryIdAsync(Guid categoryId)
    {
        var products = await _productRepository.GetAllAsync(entity => entity.CategoryId == categoryId);

        var mappedProducts = _mapper.Map<List<ProductDetailDto>>(products);

        return mappedProducts;
    }
        

    [LogAspect(typeof(FileLogger))]
    [CacheAspect(duration: durationInMinutes)]
    public async Task<List<ProductDetailDto>> GetProductDetailsAsync()
    {
        var productInfo = await _productRepository.GetProductDetailsAsync();

        var productDetails = _mapper.Map<List<ProductDetailDto>>(productInfo);

        return productDetails;
    }

    [CacheAspect(duration: durationInMinutes)]
    public async Task<List<ProductDetailDto>> GetProductDetailsByCategoryIdAsync(Guid categoryId)
    {
        var productInfo = await _productRepository.GetProductDetailsAsync(entity => entity.CategoryId == categoryId);

        var productDetails = _mapper.Map<List<ProductDetailDto>>(productInfo);

        return productDetails;
    }


    [CacheAspect(duration: durationInMinutes)]
    public async Task<List<ProductDetailDto>> GetProductDetailsBySupplierIdAsync(Guid supplierId)
    {
        var productInfo = await _productRepository.GetProductDetailsAsync(entity => entity.SupplierId == supplierId);

        var productDetails = _mapper.Map<List<ProductDetailDto>>(productInfo);

        return productDetails;
    }
}