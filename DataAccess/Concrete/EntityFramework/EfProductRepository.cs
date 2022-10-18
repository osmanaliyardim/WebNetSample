using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebNetSample.Core.DataAccess.EntityFramework;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.DataAccess.Concrete.EntityFramework.Contexts;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.DataAccess.Concrete.EntityFramework;

public class EfProductRepository : EfEntityRepositoryBase<Product, WebNetSampleDBContext>, IProductRepository
{
    public EfProductRepository(WebNetSampleDBContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<List<ProductDetailDto>> GetProductDetailsAsync(Expression<Func<Product, bool>> filter = null)
    {
        using (var context = new WebNetSampleDBContext())
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

            return await result.ToListAsync();
        }
    }
}