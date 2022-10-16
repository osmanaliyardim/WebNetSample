using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System.Linq.Expressions;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, WebNetSampleDBContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails(Expression<Func<Product, bool>> filter = null)
        {
            using (WebNetSampleDBContext context = new WebNetSampleDBContext())
            {
                var result = from product in context.Products
                                                          join category in context.Categories on product.CategoryId equals category.Id
                                                          join supplier in context.Suppliers on product.SupplierId equals supplier.Id
                                                          select new ProductDetailDto()
                                                          {
                                                              Id = product.Id,
                                                              Name = product.Name,
                                                              Price = product.Price,
                                                              ImageUrl = product.ImageUrl,
                                                              CategoryName = category.Name,
                                                              SupplierName = supplier.Name
                                                          };

                return result.ToList();
            }
        }
    }
}