using Microsoft.EntityFrameworkCore;
using SegenApi.Models;
using SegenApi.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegenApi.DbServices;

public interface IBookRepository
{
    Task<List<Item>> GetBooksAsync();
    Task<List<Item>> GetPagedBooksAsync(int pageNumZeroStart, int pageSize);

}
public class BookRepository : IBookRepository
{

    private readonly AppDbContext _dbContext;
    public BookRepository(AppDbContext dbContext)
    {

        _dbContext = dbContext;
    }
    public async Task<List<Item>> GetBooksAsync()
    {
        return await _dbContext
            .Items
            .ToListAsync();
    }

    public async Task<List<Item>> GetPagedBooksAsync(int pageNumZeroStart, int pageSize)
    {
        var result = await _dbContext
                .Items
                .OrderBy(_=>_.Price)
                .Page(pageNumZeroStart, pageSize)
                .ToListAsync();
        return result;
    }
}
