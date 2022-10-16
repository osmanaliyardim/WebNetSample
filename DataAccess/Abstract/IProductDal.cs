using Core.DataAccess;
using System.Linq.Expressions;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        public List<ProductDetailDto> GetProductDetails(Expression<Func<Product, bool>> filter = null);
    }
}