using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;

namespace WebNetSample.WebNetMVC.Components;

public class CategoriesWidget : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoriesWidget(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _categoryService.GetAllAsync();

        return View(categories);
    }
}