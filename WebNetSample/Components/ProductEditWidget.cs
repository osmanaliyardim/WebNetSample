using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;

namespace WebNetSample.WebNetMVC.Components;

public class ProductEditWidget : ViewComponent
{
    private readonly IProductService _productService;

    public ProductEditWidget(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid id)
    {
        var productToEdit = await _productService.GetByIdAsync(id);

        return View(productToEdit);
    }
}