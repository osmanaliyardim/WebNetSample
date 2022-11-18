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
    /// <returns>All of Categories</returns>
    [HttpGet]
    public async Task<ActionResult<List<CategoryDetailDto>>> GetAll() =>
                await _categoryService.GetAllAsync();

    /// <summary>
    /// Gets a specific Image.
    /// </summary>
    /// <param name="id">Image Id</param>
    /// <returns>A specific Image</returns>
    // <remarks>
    /// Sample request:
    ///
    ///     Get /Categories
    ///     {
    ///        "Id": "031ec27b-f9e4-428f-9a42-292080fe9954"
    ///     }
    /// </remarks>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<string>> GetImage(Guid id)
    {
        var result = await _categoryService.GetByIdAsync(id);

        return result.ImagePath;
    }

    /// <summary>
    /// Updates a specific Image.
    /// </summary>
    /// <param name="updatedCategory">Updated Category</param>
    /// <returns>Updated Category</returns>
    // <remarks>
    /// Sample request:
    ///
    ///     Put /Categories
    ///     {
    ///        "Id": "031ec27b-f9e4-428f-9a42-292080fe9954",
    ///        "Name": "Food",
    ///        "ImagePath": "/Images/Food.jpg"
    ///     }
    /// </remarks>
    /// <response code="200">Returns Ok if the is successfull</response>
    /// <response code="400">If there is no item with the given id</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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