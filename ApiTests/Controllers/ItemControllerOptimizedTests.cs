using Microsoft.AspNetCore.Mvc;
using Moq;
using SegenApi.Controllers;
using SegenApi.DbServices;
using SegenApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.Controllers;
public class ItemControllerOptimizedTests
{
    [Fact]
    public void Constructor_WithValidDependency_InitializesController()
    {
        // Arrange
        var bookRepositoryMock = new Mock<IBookRepository>();

        // Act
        var controller = new ItemControllerOptimized(bookRepositoryMock.Object);

        // Assert
        Assert.NotNull(controller);
        Assert.IsType<ItemControllerOptimized>(controller);
    }
    [Fact]
    public async Task GetItems_ReturnsOkResult_WithValidData()
    {
        // Arrange
        var bookRepositoryMock = new Mock<IBookRepository>();
        bookRepositoryMock.Setup(repo => repo.GetBooksAsync())
            .ReturnsAsync(new List<Item> { new Item { Id = Guid.NewGuid(), Name = "Book 1" } });
        var controller = new ItemControllerOptimized(bookRepositoryMock.Object);

        // Act
        var result = await controller.GetItems();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var items = Assert.IsType<List<Item>>(okResult.Value);
        Assert.Single(items);
    }
    [Theory]
    [InlineData(0, 10)]  // Valid page number
    public async Task GetPagedItems_ReturnsOkResult_WithValidData(int pageNumZeroStart, int pageSize)
    {
        // Arrange
        var bookRepositoryMock = new Mock<IBookRepository>();
        bookRepositoryMock.Setup(repo => repo.GetPagedBooksAsync(pageNumZeroStart, pageSize))
            .ReturnsAsync(new List<Item> { new Item { Id = Guid.NewGuid(), Name = "Book 1" } });
        var controller = new ItemControllerOptimized(bookRepositoryMock.Object);

        // Act
        var result = await controller.GetPagedItems(pageNumZeroStart, pageSize);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var items = Assert.IsType<List<Item>>(okResult.Value);
        Assert.Single(items);
    }

    [Theory]
    [InlineData(-1)] // Invalid page number
    public async Task GetPagedItems_ReturnsBadRequest_WithInvalidData(int pageNumZeroStart)
    {
        // Arrange
        var bookRepositoryMock = new Mock<IBookRepository>();
        var controller = new ItemControllerOptimized(bookRepositoryMock.Object);

        // Act
        var result = await controller.GetPagedItems(pageNumZeroStart);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Invalid Page", badRequestResult.Value);
    }
}
