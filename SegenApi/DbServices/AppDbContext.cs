using Microsoft.EntityFrameworkCore;
using SegenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SegenApi.DbServices;

[ExcludeFromCodeCoverage]
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
    /// <summary>
    /// Configure the DbContext to use the NoTracking option.
    /// To avoid the overhead of tracking changes, you can turn off change tracking in EF Core.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    public DbSet<Item> Items { get; set; } = null!;

    /// <summary>
    /// Seed the database with some books.
    /// Seeding the initial data is a common practice when working with databases.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .Property(item => item.Price)
            .HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Item>().HasData(SeedBooks());
    }
    /// <summary>
    /// Seed the database with some books.
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<Item> SeedBooks()
    {
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "The Hitchhiker's Guide to the Galaxy",
            Description = "The Hitchhiker's Guide to the Galaxy is a comic science fiction series created by Douglas Adams that has become popular among fans of the genre and members of the scientific community.",
            Price = 1.00m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "The Restaurant at the End of the Universe",
            Description = "The Restaurant at the End of the Universe (1980, ISBN 0-345-39181-0) is the second book in the Hitchhiker's Guide to the Galaxy comedy science fiction trilogy by Douglas Adams, and is a sequel.",
            Price = 1.1m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "Life, the Universe and Everything",
            Description = "Life, the Universe and Everything (1982, ISBN 0-345-39182-9) is the third book in the five-volume Hitchhiker's Guide to the Galaxy science fiction trilogy by British writer Douglas Adams.",
            Price = 1.2m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "So Long, and Thanks for All the Fish",
            Description = "So Long, and Thanks for All the Fish is the fourth book of the Hitchhiker's Guide to the Galaxy \"trilogy\" written by Douglas Adams. Its title is the message left by the dolphins when they departed Planet Earth just before it was demolished to make way for a hyperspace bypass, as described in The Hitchhiker's Guide to the Galaxy.",
            Price = 7.99m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "Mostly Harmless",
            Description = "Mostly Harmless is a 1992 novel by Douglas Adams and the fifth book in the Hitchhiker's Guide to the Galaxy series. It is described on the cover of the first editions as \"The fifth book in the increasingly inaccurately named Hitchhikers Trilogy\".",
            Price = 1.3m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "And Another Thing...",
            Description = "And Another Thing... is the sixth and final installment of Douglas Adams' The Hitchhiker's Guide to the Galaxy \"trilogy\". The book, written by Eoin Colfer, author of the Artemis Fowl series, was published on the thirtieth anniversary of the first book, 12 October 2009, in hardback.",
            Price = 1.4m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "Test book 1",
            Description =
                "some description for test book 1",
            Price = 1.5m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "Test book 2",
            Description =
                "some description for test book 1",
            Price = 1.6m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "Test book 3",
            Description =
                "some description for test book 1",
            Price = 1.7m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "Test book 4",
            Description =
                "some description for test book 1",
            Price = 1.8m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "Test book 5",
            Description =
                "some description for test book 1",
            Price = 1.9m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };
        yield return new Item
        {
            Id = Guid.NewGuid(),
            Name = "Test book 6",
            Description =
                "some description for test book 1",
            Price = 2.0m,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };

    }
}
