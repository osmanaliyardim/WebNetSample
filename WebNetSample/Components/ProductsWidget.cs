using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;

namespace WebNetSample.WebNetMVC.Components;

public class ProductsWidget : ViewComponent
{
    private readonly IProductService _productService;

    public ProductsWidget(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var products = await _productService.GetProductDetailsAsync();

        return View(products);
    }
}