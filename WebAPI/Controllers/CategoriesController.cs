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

    /// <summary>
    /// Gets all Categories.
    /// </summary>
    /// <returns>List of Categories</returns>
    [HttpGet]
    public async Task<ActionResult<List<CategoryDetailDto>>> GetAll() =>
                await _categoryService.GetAllAsync();

    /// <summary>
    /// Gets a specific Image.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ImagePath</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<string>> GetImage(Guid id)
    {
        var result = await _categoryService.GetByIdAsync(id);

        return result.ImagePath;
    }

    /// <summary>
    /// Updates a specific Image.
    /// </summary>
    /// <param name="updatedCategory"></param>
    /// <returns>Updated Category</returns>
    [HttpPut]
    public async Task<ActionResult<CategoryDetailDto>> UpdateImage(CategoryDetailDto updatedCategory)
    {
        var result = await _categoryService.UpdateAsync(updatedCategory);

        if(result != null)
        {
            return result;
        }

        return BadRequest(result);
    }
}