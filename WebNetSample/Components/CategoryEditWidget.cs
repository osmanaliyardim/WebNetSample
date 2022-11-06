using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;

namespace WebNetSample.WebNetMVC.Components;

public class CategoryEditWidget : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoryEditWidget(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid id)
    {
        var categoryToEdit = await _categoryService.GetByIdAsync(id);

        return View(categoryToEdit);
    }
}