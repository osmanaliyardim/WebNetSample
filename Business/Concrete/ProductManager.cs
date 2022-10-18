using WebNetSample.Business.Abstract;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Concrete;

public class ProductManager : IProductService
{
    private IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task Add(Product product) => _productRepository.AddAsync(product);

    public void Delete(Product product) => _productRepository.Delete(p => p.Id == product.Id);

    public void Update(Product product) => _productRepository.Update(product);

    public async Task<Product> GetByIdAsync(Guid productId) => 
        await _productRepository.GetAsync(entity => entity.Id == productId);

    public async Task<List<Product>> GetListAsync() => 
        await _productRepository.GetListAsync();

    public async Task<List<Product>> GetListByCategoryIdAsync(Guid categoryId) => 
        await _productRepository.GetListAsync(entity => entity.CategoryId == categoryId);

    public async Task<List<ProductDetailDto>> GetProductDetailsAsync() => 
        await _productRepository.GetProductDetailsAsync();

    public async Task<List<ProductDetailDto>> GetProductDetailsByCategoryIdAsync(Guid categoryId) => 
        await _productRepository.GetProductDetailsAsync(entity => entity.CategoryId == categoryId);

    public async Task<List<ProductDetailDto>> GetProductDetailsBySupplierIdAsync(Guid supplierId) => 
        await _productRepository.GetProductDetailsAsync(entity => entity.SupplierId == supplierId);

}