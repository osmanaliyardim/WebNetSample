using Entity.Concrete;
using WebNetSample.Core.Pagination;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Abstract;

public interface IProductService
{

    Task<List<Product>> GetListAsync(PaginationParameters paginationParameters);

    Task<List<Product>> GetListByCategoryIdAsync(Guid categoryId);

    Task<List<ProductDetails>> GetProductDetailsAsync();

    Task<List<ProductDetails>> GetProductDetailsByCategoryIdAsync(Guid categoryId);

    Task<List<ProductDetails>> GetProductDetailsBySupplierIdAsync(Guid supplierId);

    Task<Product> GetByIdAsync(Guid productId);

    Task AddAsync(Product product);

    void Delete(Product product);

    void Update(Product product);

}