using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;

namespace WebNetSample.WebNetMVC.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var productsWithDetails = await _productService.GetProductDetailsAsync();

        return View(productsWithDetails);
    }
}