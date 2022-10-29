﻿using AutoMapper;
using Core.Aspects.Logging;
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

    public ProductManager(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    [CacheRemoveAspect("IProductService.Get")]
    public async Task AddAsync(Product product) => 
        await _productRepository.AddAsync(product);

    [CacheRemoveAspect("IProductService.Get", Priority = 1)]
    public async Task DeleteAsync(Product product) => 
        await _productRepository.DeleteAsync(p => p.Id == product.Id);

    [CacheRemoveAspect("IProductService.Get")]
    public async Task UpdateAsync(Product product) => 
        await _productRepository.UpdateAsync(product);

    [CacheAspect(duration: 30)]
    public async Task<Product> GetByIdAsync(Guid productId) =>
        await _productRepository.GetAsync(entity => entity.Id == productId);

    [LogAspect(typeof(FileLogger))]
    [CacheAspect(duration:20)]
    public async Task<List<Product>> GetListAsync(PaginationParameters paginationParameters) =>
        _productRepository.GetListAsync().Result
            .Skip(paginationParameters.RecordsToSkip)
                .Take(paginationParameters.PageSize).ToList();

    public async Task<List<Product>> GetListByCategoryIdAsync(Guid categoryId) =>
        await _productRepository.GetListAsync(entity => entity.CategoryId == categoryId);

    [LogAspect(typeof(FileLogger))]
    [CacheAspect(duration: 20)]
    public async Task<List<ProductDetailDto>> GetProductDetailsAsync()
    {
        var productInfo = await _productRepository.GetProductDetailsAsync();

        var productDetails = _mapper.Map<List<ProductDetailDto>>(productInfo);

        return productDetails;
    }

    [CacheAspect(duration: 20)]
    public async Task<List<ProductDetailDto>> GetProductDetailsByCategoryIdAsync(Guid categoryId)
    {
        var productInfo = await _productRepository.GetProductDetailsAsync(entity => entity.CategoryId == categoryId);

        var productDetails = _mapper.Map<List<ProductDetailDto>>(productInfo);

        return productDetails;
    }

    [CacheAspect(duration: 20)]
    public async Task<List<ProductDetailDto>> GetProductDetailsBySupplierIdAsync(Guid supplierId)
    {
        var productInfo = await _productRepository.GetProductDetailsAsync(entity => entity.SupplierId == supplierId);

        var productDetails = _mapper.Map<List<ProductDetailDto>>(productInfo);

        return productDetails;
    }
}