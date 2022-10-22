using System.Linq.Expressions;
using WebNetSample.Core.DataAccess;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.DataAccess.Abstract;

public interface IProductRepository : IEntityRepository<Product>
{
    Task<List<ProductDetails>> GetProductDetailsAsync(Expression<Func<Product, bool>> filter = null);
}