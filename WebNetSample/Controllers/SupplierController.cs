using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;

namespace WebNetSample.WebNetMVC.Controllers;

public class SuppliersController : Controller
{
    private readonly ISupplierService _supplierService;

    public SuppliersController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var suppliers = await _supplierService.GetAllAsync();    

        return View(suppliers);
    }
}