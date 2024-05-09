using kolokwium_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_1.Controllers;

[ApiController]
[Route("api/[controller]")] //api/groups
public class GroupsController(IService service) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var res = await service.GetGroupDetailsByIdAsync(id);
        if (res is null) return NotFound($"group with id:{id} doesn't exist");
        return Ok(res);
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

