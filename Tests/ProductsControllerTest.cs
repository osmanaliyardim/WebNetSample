using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebNetSample.WebNetMVC.Controllers;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Dtos;
using WebNetSample.Tests.Configurations;
using WebNetSample.Entity.Concrete;
using WebNetSample.Core.Extensions;

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

    [Theory, AutoMoqData]
    public void Index_ShouldThrowExceptionAndReturnErrorDetails_WhenErrorOccurs(AggregateException expected) //ErrorDetails
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var sut = new ProductsController(productServiceMock.Object, configurationMock.Object);
        productServiceMock.Setup(productService => productService.GetProductDetailsAsync().Exception).Returns(expected);

        // Act
        var actionResult = sut.Index();

        // Assert
        var errorViewResult = actionResult;
        Assert.Throws<ErrorDetails>(errorViewResult.Result);
        Assert.IsType<ErrorDetails>(errorViewResult.Exception);

        var model = errorViewResult;
        Assert.Throws<ErrorDetails>(model.Result);
        Assert.IsType<ErrorDetails>(model.Exception);

        var actual = model;

        Assert.Equal(actual.Exception, expected);
    }

    [Theory, AutoMoqData]
    public void Add_ShouldExecuteSuccessullyAndAddProductToDB(Product expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var sut = new ProductsController(productServiceMock.Object, configurationMock.Object);
        var result = productServiceMock.Setup(productService => productService.AddAsync(expected));

        // Act
        var actionResult = sut.Add(expected);

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as Product;
        Assert.NotNull(model);

        var actual = model;

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.SupplierId, actual.SupplierId);
        Assert.Equal(expected.CategoryId, actual.CategoryId);
        Assert.Equal(expected.ImageUrl, actual.ImageUrl);
        Assert.Equal(expected.Price, actual.Price);
    }

    [Theory, AutoMoqData]
    public void Edit_ShouldExecuteSuccessullyAndReturnProduct(Product expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var sut = new ProductsController(productServiceMock.Object, configurationMock.Object);
        productServiceMock.Setup(productService => productService.GetByIdAsync(expected.Id).Result).Returns(expected);

        // Act
        var actionResult = sut.Edit(expected.Id);

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as Product;
        Assert.NotNull(model);

        var actual = model;

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.SupplierId, actual.SupplierId);
        Assert.Equal(expected.CategoryId, actual.CategoryId);
        Assert.Equal(expected.ImageUrl, actual.ImageUrl);
        Assert.Equal(expected.Price, actual.Price);
    }

    [Theory, AutoMoqData]
    public void Update_ShouldExecuteSuccessullyAndRedirectToAction(Product expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var sut = new ProductsController(productServiceMock.Object, configurationMock.Object);
        productServiceMock.Setup(productService => productService.UpdateAsync(expected));

        // Act
        var actionResult = sut.Update(expected);

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as Product;
        Assert.NotNull(model);

        var actual = model;

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.SupplierId, actual.SupplierId);
        Assert.Equal(expected.CategoryId, actual.CategoryId);
        Assert.Equal(expected.ImageUrl, actual.ImageUrl);
        Assert.Equal(expected.Price, actual.Price);
    }
}