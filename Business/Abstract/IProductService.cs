using System.Linq.Expressions;
using WebNetSample.Core.Pagination;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Abstract;

public interface IProductService
{
    Task<List<ProductDetailDto>> GetAllAsync(PaginationParameters paginationParameters);

    Task<List<ProductDetailDto>> GetProductDetailsAsync();

    Task<List<ProductDetailDto>> GetProductDetailsByCategoryIdAsync(Guid categoryId);

    Task<List<ProductDetailDto>> GetProductDetailsBySupplierIdAsync(Guid supplierId);

    Task<ProductDetailDto> GetByIdAsync(Guid productId);

    Task AddAsync(ProductDetailDto product);

    Task DeleteAsync(ProductDetailDto product);

    Task UpdateAsync(ProductDetailDto product);
}