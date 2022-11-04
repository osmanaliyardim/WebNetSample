using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Dtos;
using WebNetSample.WebNetMVC.Controllers;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.Tests;
/*
public class ProductsControllerTest
{
    [Theory, AutoMoqData]
    public void Index_ShouldExecuteSuccessullyAndReturnCategories(List<ProductDetailDto> expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var productsController = new ProductsController(productServiceMock.Object, configurationMock.Object);
        productServiceMock.Setup(productService => productService.GetProductDetailsAsync().Result).Returns(expected);

        // Act
        var actionResult = productsController.Index();

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as List<ProductDetailDto>;
        Assert.NotNull(model);

        var actual = model;

        Assert.Equal(expected.Count, actual.Count);

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

    [Fact, AutoMoqData]
    public void Add_ShouldExecuteSuccessullyAndRedirectToIndex()
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        var productsController = new ProductsController(productServiceMock.Object, configurationMock.Object);

        Product expected = new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Blabla",
            ImagePath = "Aaa.jpg",
            Price = 10.04m,
            CreationDate = DateTime.Now,
            CategoryId = Guid.NewGuid(),
            SupplierId = Guid.NewGuid()
        };

        // Act
        var actionResult = productsController.Add(expected);

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.Null(okViewResult);
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
    public void Update_ShouldExecuteSuccessullyAndRedirectToIndex(Product expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>();

        Product product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Blabla",
            ImagePath = "Aaa.jpg",
            Price = 10.04m,
            CreationDate = DateTime.Now,
            CategoryId = Guid.NewGuid(),
            SupplierId = Guid.NewGuid()
        };

        var productsController = new ProductsController(productServiceMock.Object, configurationMock.Object);
        productServiceMock.Setup(productService => productService.UpdateAsync(product)).Returns(Task.FromResult(expected));  

        // Act
        var actionResult = productsController.Update(expected);

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as ProductDetailDto;
        Assert.NotNull(model);

        var actual = model;

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.ImagePath, actual.ImagePath);
        Assert.Equal(expected.Price, actual.Price);
    }
}
*/