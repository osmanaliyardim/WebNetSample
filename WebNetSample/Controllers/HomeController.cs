using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;

namespace WebNetSample.WebNetMVC.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService _categoryService;

    public HomeController(ICategoryService categoryService)
    {
        _categoryService = categoryService; 
    }

    [HttpGet]
    public IActionResult Index()
    {
        var categoryImages = _categoryService.GetAllAsync();

        return View(categoryImages.Result);
    }
}