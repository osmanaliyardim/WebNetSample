using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.WebNetMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService categoryService,
        IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetListAsync();

        return View(categories);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(CategoryDetailDto category)
    {
        await _categoryService.AddAsync(category);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var categoryToEdit = await _categoryService.GetByIdAsync(id);

        return View(categoryToEdit);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CategoryDetailDto updatedCategory)
    {
        await _categoryService.UpdateAsync(updatedCategory);

        return RedirectToAction("Index");
    }
}