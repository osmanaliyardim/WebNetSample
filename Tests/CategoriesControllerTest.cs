﻿using Microsoft.AspNetCore.Mvc;
using WebNetSample.Business.Abstract;
using WebNetSample.Entity.Concrete;
using WebNetSample.Tests.Configurations;
using WebNetSample.WebNetMVC.Controllers;

namespace WebNetSample.Tests;

public class CategoriesControllerTest
{
    [Theory, AutoMoqData]
    public void Index_Should_Return_As_Expected(List<Category> expected)
    {
        // Arrange
        var productServiceMock = new Mock<ICategoryService>();

        var sut = new CategoriesController(productServiceMock.Object);
        productServiceMock.Setup(c => c.GetListAsync().Result).Returns(expected);

        // Act
        var actionResult = sut.Index();

        // Assert
        var okViewResult = actionResult.Result as ViewResult;
        Assert.NotNull(okViewResult);

        var model = okViewResult.Model as List<Category>;
        Assert.NotNull(model);

        var actual = model;

        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }
}