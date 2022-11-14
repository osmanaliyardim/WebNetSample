using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Gets all Products.
    /// </summary>
    /// <returns>List of Products</returns>
    [HttpGet]
    public async Task<ActionResult<List<ProductDetailDto>>> GetAll() =>
              await _productService.GetProductDetailsAsync();

    /// <summary>
    /// Posts a specific Product.
    /// </summary>
    /// <param name="product"></param>
    /// <returns>Task Result</returns>
    [HttpPost]
    public async Task<ActionResult<Task>> Add(ProductDetailDto product)
    {
        var taskResult = _productService.AddAsync(product);

        if (taskResult.IsCompletedSuccessfully)
        {
            return taskResult;
        }

        return BadRequest(taskResult);
    }

    /// <summary>
    /// Updates a specific Product.
    /// </summary>
    /// <param name="product"></param>
    /// <returns>Updated Product</returns>
    [HttpPut]
    public async Task<ActionResult<ProductDetailDto>> Update(ProductDetailDto product)
    {
        var result = await _productService.UpdateAsync(product);

        if (result != null)
        {
            return result;
        }

        return BadRequest(result);
    }

    /// <summary>
    /// Removes a specific Product.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Task Result</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     Delete /Products
    ///     {
    ///        "Id": "031ec27b-f9e4-428f-9a42-292080fe9954"
    ///     }
    /// </remarks>
    /// <response code="204">Returns the task result</response>
    /// <response code="400">If there is no item with the given id</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Task>> Delete(Guid id)
    {
        var productToDelete = await _productService.GetByIdAsync(id);

        var taskResult = _productService.DeleteAsync(productToDelete);

        if (taskResult.IsCompletedSuccessfully)
        {
            return taskResult;
        }

        return BadRequest(taskResult.Status);
    }
}