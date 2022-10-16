using Business.Abstract;
using DataAccess.Abstract;
using WebNetSample.Entity.Concrete;

namespace Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        private ISupplierDal _supplierDal;
        private IProductService _productService;

        public SupplierManager(ISupplierDal supplierDal, IProductService productService)
        {
            _supplierDal = supplierDal;
            _productService = productService;
        }

        public void Add(Supplier product)
        {
            _supplierDal.Add(product);
        }

        public void Delete(Supplier product)
        {
            _supplierDal.Delete(product);
        }

        public void Update(Supplier product)
        {
            _supplierDal.Update(product);
        }

        public Supplier GetById(int productId)
        {
            return _supplierDal.Get(x => x.Id == productId);
        }

        public List<Supplier> GetList()
        {
            return _supplierDal.GetList().ToList();
        }
    }
}