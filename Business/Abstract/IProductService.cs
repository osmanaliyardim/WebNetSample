using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        List<Product> GetListByCategory(int categoryId);
        List<ProductDetailDto> GetProductDetails();
        List<ProductDetailDto> GetProductDetailsByCategory(int categoryId);
        List<ProductDetailDto> GetProductDetailsBySupplier(int supplierId);
        Product GetById(int productId);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}