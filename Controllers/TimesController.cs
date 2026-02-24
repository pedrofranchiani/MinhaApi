namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TimesController : ControllerBase
{
    private static List<Times> _times = new();
    

    [HttpGet("listar")]
    public ActionResult<List<Times>> Get() => _times;
    
    [HttpPost("adicionar")]
    public ActionResult<Times> Post([FromBody] Times time)
    {
        _times.Add(time);
        return CreatedAtAction(nameof(Get), new { id = time.Id }, time);
    }
    
}