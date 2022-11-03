using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Concrete;
using WebNetSample.Tests.Configurations;
using WebNetSample.WebNetMVC.Controllers;

namespace WebNetSample.Tests;

public class CategoriesControllerTest
{
    [Theory, AutoMoqData]
    public void Index_ShouldReturnAsExpected(List<Category> expected)
    {
        // Arrange
        var categoriesServiceMock = new Mock<ICategoryService>();

        var categoriesController = new CategoriesController(categoriesServiceMock.Object);
        categoriesServiceMock.Setup(categoriesService => categoriesService.GetListAsync().Result).Returns(expected);

        // Act
        var actionResult = categoriesController.Index();

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as List<Category>;
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