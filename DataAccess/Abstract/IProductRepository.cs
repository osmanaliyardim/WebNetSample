using System.Linq.Expressions;
using Entity.Concrete;
using WebNetSample.Core.DataAccess;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.DataAccess.Abstract;

public interface IProductRepository : IEntityRepository<Product>
{
    Task<List<ProductDetails>> GetProductDetailsAsync(Expression<Func<Product, bool>> filter = null);
}