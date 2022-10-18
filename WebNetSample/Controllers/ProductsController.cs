﻿using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Core.Pagination;
using WebNetSample.Entity.Concrete;
using Newtonsoft.Json;

namespace WebNetSample.WebNetMVC.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly PaginationParameters _paginationParameters;

    public ProductsController(IProductService productService, PaginationParameters paginationParameters)
    {
        _productService = productService;
        _paginationParameters = paginationParameters;
    }

    public async Task<IActionResult> Index()
    {
        var productsWithDetails = await _productService.GetProductDetailsAsync();

        return View(productsWithDetails);
    }

    public async Task<IActionResult> AllProducts()
    {
        var productsWithDetails = await _productService.GetListAsync(_paginationParameters);

        return View(productsWithDetails);
    }

    [HttpGet]
    public IActionResult Add()
    {
        Guid id = Guid.NewGuid();
        DateTime date = DateTime.Now;

        ViewBag.Id = id;
        ViewBag.CreationDate = date;

        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Add(Product product)
    {
        await _productService.AddAsync(product);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(string productToEdit)
    {
        var product = JsonConvert.DeserializeObject<Product>(productToEdit);

        return View(product);
    }

    [HttpPost]
    public IActionResult Update(Product updatedProduct)
    {
        _productService.Update(updatedProduct);

        return RedirectToAction("Index");
    }
}