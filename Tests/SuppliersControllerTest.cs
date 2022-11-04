using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;
using WebNetSample.Tests.Configurations;
using WebNetSample.WebNetMVC.Controllers;

namespace WebNetSample.Tests;

public class SuppliersControllerTest
{
    [Theory, AutoMoqData]
    public void Index_ShouldReturnAsExpected(List<Supplier> expected)
    {
        // Arrange
        var supplierServiceMock = new Mock<ISupplierService>();

        var suppliersController = new SuppliersController(supplierServiceMock.Object);
        supplierServiceMock.Setup(supplierService => supplierService.GetListAsync().Result).Returns(expected);

        // Act
        var actionResult = suppliersController.Index();

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as List<SupplierDetailDto>;
        Assert.NotNull(model);

        var actual = model;

        Assert.Equal(expected.Count, actual.Count);

        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i].Name, actual[i].Name);
            Assert.Equal(expected[i].CreationDate, actual[i].CreationDate);
        }
    }
}
