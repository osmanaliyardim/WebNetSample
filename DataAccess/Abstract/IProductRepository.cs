using System.Linq.Expressions;
using WebNetSample.Core.DataAccess;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.DataAccess.Abstract;

public interface IProductRepository : IEntityRepository<Product>
{

}