using System.Linq.Expressions;
using WebNetSample.Core.Pagination;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.Business.Abstract;

public interface IProductService
{

    Task<List<Product>> GetListAsync(PaginationParameters paginationParameters);

    Task<List<Product>> GetListByCategoryIdAsync(Guid categoryId);

    Task<List<ProductDetailDto>> GetProductDetailsAsync(Expression<Func<Product, bool>> filter = null);

    Task<Product> GetByIdAsync(Guid productId);

    Task AddAsync(Product product);

    void Delete(Product product);

    void Update(Product product);

}