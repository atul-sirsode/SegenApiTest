using Microsoft.EntityFrameworkCore;
using SegenApi.DbServices;
using SegenApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.DbServices;
public class BookRepositoryTests : IDisposable
{
    private AppDbContext _dbContext;
    private readonly DbContextOptions<AppDbContext> _options;
    public BookRepositoryTests()
    {
        // Run before each test
        // Use InMemoryDatabase for testing
        // use uid to create a unique name for the DB to avoid conflicts and collisions
        _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
       
    }

    [Fact]
    public async Task GetBooksAsync_ReturnsListOfItems()
    {
        // Arrange
        _dbContext = new AppDbContext(_options);
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 1" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 2" });
        await _dbContext.SaveChangesAsync();

        var repository = new BookRepository(_dbContext);

        // Act
        var result = await repository.GetBooksAsync();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Item>>(result);
        Assert.Equal(2, result.Count);
    }
    [Fact]
    public async Task GetPagedBooksAsync_ReturnsPagedListOfItems()
    {
        // Arrange
        _dbContext = new AppDbContext(_options);
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 1" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 2" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 3" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 4" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 5" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 6" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 7" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 8" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 9" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 10" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 11" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 12" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 13" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 14" });
        _dbContext.Items.Add(new Item { Id = Guid.NewGuid(), Name = "Book 15" });
        // Add _dbContext items as needed
        await _dbContext.SaveChangesAsync();

        var repository = new BookRepository(_dbContext);
        const int pageNumZeroStart = 0;
        const int pageSize = 10;

        // Act
        var result = await repository.GetPagedBooksAsync(pageNumZeroStart, pageSize);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Item>>(result);
        Assert.Equal(10, result.Count);

        // Additional Assertions for Paging
        var nextResult = await repository.GetPagedBooksAsync(pageNumZeroStart + 1, pageSize);
        Assert.NotNull(nextResult);
        Assert.IsType<List<Item>>(nextResult);
        Assert.Equal(5, nextResult.Count); // Only 1 item on the next page
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}
