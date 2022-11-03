using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebNetSample.WebNetMVC.Controllers;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Dtos;
using WebNetSample.Tests.Configurations;
using WebNetSample.Entity.Concrete;
using WebNetSample.Core.Extensions;
using System;

namespace WebNetSample.Tests;

public class ProductsControllerTest
{
    [Theory, AutoMoqData]
    public void Index_ShouldExecuteSuccessullyAndReturnCategories(List<ProductDetailDto> expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var sut = new ProductsController(productServiceMock.Object, configurationMock.Object);
        productServiceMock.Setup(productService => productService.GetProductDetailsAsync().Result).Returns(expected);

        // Act
        var actionResult = sut.Index();

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as List<ProductDetailDto>;
        Assert.NotNull(model);

        var actual = model;

        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i].Name, actual[i].Name);
            Assert.Equal(expected[i].SupplierName, actual[i].SupplierName);
            Assert.Equal(expected[i].CategoryName, actual[i].CategoryName);
            Assert.Equal(expected[i].ImageUrl, actual[i].ImageUrl);
            Assert.Equal(expected[i].Price, actual[i].Price);
        }
    }

    [Fact]
    public async Task Index_ShouldThrowExceptionAndReturnErrorDetails_WhenErrorOccurs()
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var productsController = new ProductsController(productServiceMock.Object, configurationMock.Object);

        var expected = new Exception();

        productServiceMock.Setup(productService => productService.GetProductDetailsAsync()).ThrowsAsync(expected);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => productsController.Index());
    }

    [Theory, AutoMoqData]
    public void Add_ShouldExecuteSuccessullyAndRedirectToIndex(Product expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var productsController = new ProductsController(productServiceMock.Object, configurationMock.Object);

        // Act
        var actionResult = productsController.Add(expected);

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);
    }

    [Theory, AutoMoqData]
    public void Edit_ShouldExecuteSuccessullyAndReturnProduct(Guid expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var productsController = new ProductsController(productServiceMock.Object, configurationMock.Object);

        // Act
        var actionResult = productsController.Edit(expected);

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);
    }

    [Theory, AutoMoqData]
    public void Update_ShouldExecuteSuccessullyAndRedirectToAction(Product expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var productsController = new ProductsController(productServiceMock.Object, configurationMock.Object);

        // Act
        var actionResult = productsController.Update(expected);

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as Product;
        Assert.NotNull(model);

        var actual = model;

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.ImageUrl, actual.ImageUrl);
        Assert.Equal(expected.Price, actual.Price);
    }
}