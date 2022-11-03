﻿using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Core.Pagination;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.WebNetMVC.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly IConfiguration _configuration;

    public ProductsController(IProductService productService, IConfiguration configuration)
    {
        _productService = productService;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var productsWithDetails = await _productService.GetProductDetailsAsync();

        return View(productsWithDetails);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        const string paginationSectionName = "PaginationLimitsAndOffsets";

        var paginationJson = _configuration.GetSection(paginationSectionName);

        var paginationParameters = paginationJson.Get<PaginationParameters>();

        var productsWithDetails = await _productService.GetListAsync(paginationParameters);

        return View(productsWithDetails);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        await _productService.AddAsync(product);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var productToEdit = await _productService.GetByIdAsync(id);

        return View(productToEdit);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Product updatedProduct)
    {
        await _productService.UpdateAsync(updatedProduct);

        return RedirectToAction("Index");
    }
}