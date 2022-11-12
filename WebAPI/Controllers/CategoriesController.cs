using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDetailDto>>> GetAll()
    {
        var result = await _categoryService.GetAllAsync();

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<string>> GetImage(Guid id)
    {
        var result = await _categoryService.GetByIdAsync(id);

        return Ok(result.ImagePath);
    }

    [HttpPost]
    public async Task<ActionResult<Task>> UpdateImage(CategoryDetailDto updatedCategory)
    {
        var result = _categoryService.UpdateAsync(updatedCategory);

        if (result.IsCompletedSuccessfully)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}