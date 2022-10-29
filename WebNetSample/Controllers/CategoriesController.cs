using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.WebNetMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
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
    public async Task<IActionResult> Add(Category category)
    {
        await _categoryService.AddAsync(category);

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("/Categories/Update/{id}")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var categoryToEdit = await _categoryService.GetByIdAsync(id);

        return View(categoryToEdit);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Category updatedCategory)
    {
        string FileName = Path.GetFileNameWithoutExtension(updatedCategory.ImageFile?.FileName);
 
        string FileExtension = Path.GetExtension(updatedCategory.ImageFile?.FileName);
  
        FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName?.Trim() + FileExtension;

        string UploadPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Images\\";

        updatedCategory.ImagePath = UploadPath + FileName;

        using (Stream fileStream = new FileStream(updatedCategory.ImagePath, FileMode.Create, FileAccess.Write))
        {
            updatedCategory.ImageFile?.CopyTo(fileStream);
        }

        updatedCategory.ImagePath = "\\Images\\" + FileName;

        await _categoryService.UpdateAsync(updatedCategory);

        return RedirectToAction("Index");
    }
}