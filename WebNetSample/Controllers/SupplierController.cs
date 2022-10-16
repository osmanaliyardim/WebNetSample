using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.WebNetMVC.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            List<Supplier> suppliers = _supplierService.GetList();    

            return View(suppliers);
        }
    }
}
