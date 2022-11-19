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
    public async Task<ActionResult<List<ProductDetailDto>>> GetAll() =>
              await _productService.GetProductDetailsAsync();

    [HttpPost]
    public async Task<ActionResult> Add(ProductDetailDto product)
    {
        await _productService.AddAsync(product);

        return RedirectToAction("Index");
    }

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

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Task>> Delete(Guid id)
    {
        var productToDelete = await _productService.GetByIdAsync(id);

        await _productService.DeleteAsync(productToDelete);

        return RedirectToAction("Index");
    }
}