using WebNetSample.Entity.Concrete;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        List<Supplier> GetList();
        Supplier GetById(int supplierId);
        void Add(Supplier supplier);
        void Delete(Supplier supplier);
        void Update(Supplier supplier);
    }
}