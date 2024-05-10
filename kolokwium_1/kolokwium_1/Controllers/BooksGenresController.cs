using kolokwium_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_1.Controllers;

[ApiController]
[Route("api/books")] //api/groups
public class BooksGenresController : ControllerBase
{

    private IService _service;

    public BooksGenresController(IService service)
    {
        _service = service;
    }


    [HttpGet("{id:int}/genres")]
    public async Task<IActionResult> Get(int id)
    {
        var res = await _service.GetGenresByIdAsync(id);
        if (res is null) return NotFound($"book with id:{id} doesn't exist");
        
        return Ok(res);
    }

    [HttpPut("")]
    public async Task<IActionResult> Put(string bookTitle, List<int> genres)
    {
        var res = await _service.AddBook(bookTitle, genres);
        if (res)
        {
            Book.idCount++;
        }

        return NoContent();
    }
    
    /*[HttpDelete("{id:int}")]
    public async Task<IActionResult> Remove(int id)
    {
        var res = await service...
        if (res) return NoContent();
        return NotFound($"student with id:{id} doesn't exist");
    }*/

    /*[HttpPost()]
    public async...

    {
        return StatusCodes(StatusCodes.Status201Created);
    }*/
    
    /*[HttpPut("{object:Object}")]
    public async ...
    {
        return NoContent();
    }*/
}

