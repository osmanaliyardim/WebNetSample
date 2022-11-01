using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Dtos;
using WebNetSample.WebNetMVC.Controllers;

namespace WebNetSample.Tests;

public class SuppliersControllerTest
{
    [Theory, AutoMoqData]
    public void Index_Should_Return_As_Expected(List<SupplierDetailDto> expected)
    {
        // Arrange
        var productServiceMock = new Mock<ISupplierService>();

        var sut = new SuppliersController(productServiceMock.Object);
        productServiceMock.Setup(c => c.GetAllAsync().Result).Returns(expected);

        // Act
        var actionResult = sut.Index();

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as List<SupplierDetailDto>;
        Assert.NotNull(model);

        var actual = model;

        for (int i = 0; i < actual.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }
}
