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
    private readonly WebNetSampleDBContext context;

    public EfProductRepository(WebNetSampleDBContext databaseContext) : base(databaseContext)
    {
        context = databaseContext;
    }

    public async Task<List<Product>> GetProductDetailsAsync(Expression<Func<Product, bool>> filter = null)
    {
        var result = from product in context.Products
                     join category in context.Categories on product.CategoryId equals category.Id
                     join supplier in context.Suppliers on product.SupplierId equals supplier.Id
                     select new Product()
                     {
                         Id = product.Id,
                         Name = product.Name,
                         Price = product.Price,
                         ImagePath = product.ImagePath,
                         CategoryId = category.Id,
                         SupplierId = supplier.Id
                     };

        return await result.ToListAsync();
    }
}