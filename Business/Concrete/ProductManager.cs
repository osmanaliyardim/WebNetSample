using Business.Abstract;
using DataAccess.Abstract;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.Id == productId);
        }

        public List<Product> GetList()
        {
            return _productDal.GetList().ToList();
        }

        public List<Product> GetListByCategory(int categoryId)
        {
            return _productDal.GetList(x => x.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        public List<ProductDetailDto> GetProductDetailsByCategory(int categoryId)
        {
            return _productDal.GetProductDetails(p => p.CategoryId == categoryId);
        }

        public List<ProductDetailDto> GetProductDetailsBySupplier(int supplierId)
        {
            return _productDal.GetProductDetails(p => p.SupplierId == supplierId);
        }
    }
}