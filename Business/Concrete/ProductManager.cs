using System.Collections.Generic;
using System.Linq.Expressions;
using WebNetSample.Business.Abstract;
using WebNetSample.Business.ValidationRules.FluentValidation;
using WebNetSample.Core.Aspects.Validation;
using WebNetSample.Core.Pagination;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISupplierRepository _supplierRepository;

    public ProductManager(IProductRepository productRepository, ICategoryRepository categoryRepository,
        ISupplierRepository supplierRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _supplierRepository = supplierRepository;
    }

    public Task AddAsync(Product product) =>
        _productRepository.AddAsync(product);

    public void Delete(Product product) =>
        _productRepository.Delete(p => p.Id == product.Id);

    public void Update(Product product) =>
        _productRepository.Update(product);

    public async Task<Product> GetByIdAsync(Guid productId) => 
        await _productRepository.GetAsync(entity => entity.Id == productId);

    public async Task<List<Product>> GetListAsync(PaginationParameters paginationParameters) =>
        _productRepository.GetListAsync().Result
            .Skip((paginationParameters.RecordsToSkip))
                .Take(paginationParameters.PageSize).ToList();

    public async Task<List<Product>> GetListByCategoryIdAsync(Guid categoryId) => 
        await _productRepository.GetListAsync(entity => entity.CategoryId == categoryId);

    public async Task<List<ProductDetailDto>> GetProductDetailsAsync(Expression<Func<Product, bool>> filter = null)
    {
        var result = (from product in _productRepository.GetListAsync().Result
                     join category in _categoryRepository.GetListAsync().Result on product.CategoryId equals category.Id
                     join supplier in _supplierRepository.GetListAsync().Result on product.SupplierId equals supplier.Id
                     select new ProductDetailDto()
                     {
                         Id = product.Id,
                         Name = product.Name,
                         Price = product.Price,
                         ImageUrl = product.ImageUrl,
                         CategoryName = category.Name,
                         SupplierName = supplier.Name
                     }).ToList();

        var taskResult = await Task.FromResult(result);

        return taskResult;
    }
}