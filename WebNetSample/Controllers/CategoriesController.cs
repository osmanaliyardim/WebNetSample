using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;

namespace WebNetSample.WebNetMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetListAsync();

        return View(categories);
    }
}