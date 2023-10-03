using Microsoft.AspNetCore.Mvc;
using SegenApi.DbServices;
using System.Threading.Tasks;

namespace SegenApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemControllerOptimized : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    /// <summary>
    /// Using Repository Pattern to access the database and return the data
    /// </summary>
    /// <param name="bookRepository"></param>
    public ItemControllerOptimized(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    /// <summary>
    /// This method returns all the items from the database
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetItems()
    {
        var response = await _bookRepository.GetBooksAsync();
        return Ok(response);
    }

    /// <summary>
    /// This method returns the items from the database based on the page number and page size
    /// Default page number is 0 and default page size is 10
    /// if want Next set of records then pass page number as 1 and page size as 10 and so on
    /// </summary>
    /// <param name="pageNumZeroStart"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>

    [HttpGet]
    [Route("paged")]
    public async Task<IActionResult> GetPagedItems(int pageNumZeroStart = 0, int pageSize = 10)
    {
        if (pageNumZeroStart < 0)
        {
            return BadRequest("Invalid Page");
        }
        var response = await _bookRepository.GetPagedBooksAsync(pageNumZeroStart, pageSize);
        return Ok(response);
    }
}
