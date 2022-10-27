using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebNetSample.WebNetMVC.Controllers;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Dtos;
using WebNetSample.Tests.Configurations;

namespace WebNetSample.Tests;

public class ProductsControllerTest
{
    [Theory, AutoMoqData]
    public void Index_Should_Return_As_Expected(List<ProductDetailDto> expected)
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var productServiceMock = new Mock<IProductService>(); 

        var sut = new ProductsController(productServiceMock.Object, configurationMock.Object);
        productServiceMock.Setup(c => c.GetProductDetailsAsync().Result).Returns(expected);

        // Act
        var actionResult = sut.Index();

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as List<ProductDetailDto>;
        Assert.NotNull(model);

        var actual = model;

        for (int i = 0; i < actual.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }
}