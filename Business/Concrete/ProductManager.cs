using AutoMapper;
using Core.Aspects.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

    public async Task AddAsync(ProductDetailDto product)
    {
        var mappedProduct = _mapper.Map<Product>(product);

        await _productRepository.AddAsync(mappedProduct);
    }

    public async Task DeleteAsync(ProductDetailDto product) => 
        await _productRepository.DeleteAsync(p => p.Id == product.Id);

    public async Task UpdateAsync(ProductDetailDto product)
    {
        var mappedProduct = _mapper.Map<Product>(product);

        await _productRepository.UpdateAsync(mappedProduct);
    }

    public async Task<ProductDetailDto> GetByIdAsync(Guid productId)
    {
        var productInfo = await _productRepository.GetAsync(product => product.Id == productId);

        var productDetails = _mapper.Map<ProductDetailDto>(productInfo);

        return productDetails;
    }

    [LogAspect(typeof(FileLogger))]
    public async Task<List<ProductDetailDto>> GetListAsync(PaginationParameters paginationParameters)
    {
        var productsInfo = await _productRepository.GetListAsync();

        var paginationProductsInfo = productsInfo
                .Skip(paginationParameters.RecordsToSkip)
                    .Take(paginationParameters.PageSize).ToList();

        var productDetailsList = _mapper.Map<List<ProductDetailDto>>(productsInfo);

        return productDetailsList;
    }

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