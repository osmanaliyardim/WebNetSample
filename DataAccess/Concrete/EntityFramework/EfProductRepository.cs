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
}