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

    [HttpGet]
    public async Task<ActionResult<List<ProductDetailDto>>> GetAll()
    {
        var result = await _productService.GetProductDetailsAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Task>> Add(ProductDetailDto product)
    {
        var taskResult = _productService.AddAsync(product);

        if (taskResult.IsCompletedSuccessfully)
        {
            return Ok(taskResult);
        }

        return BadRequest(taskResult);
    }

    [HttpPost]
    public async Task<ActionResult<Task>> Update(ProductDetailDto product)
    {
        var taskResult = _productService.UpdateAsync(product);

        if (taskResult.IsCompletedSuccessfully)
        {
            return Ok(taskResult);
        }

        return BadRequest(taskResult.Status);
    }

    [HttpDelete]
    public async Task<ActionResult<Task>> Delete(ProductDetailDto product)
    {
        var taskResult = _productService.DeleteAsync(product);

        if (taskResult.IsCompletedSuccessfully)
        {
            return Ok(taskResult);
        }

        return BadRequest(taskResult.Status);
    }
}