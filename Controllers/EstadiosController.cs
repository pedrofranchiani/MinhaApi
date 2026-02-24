namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EstadiosController : ControllerBase
{
    private static List<Estadios> _estadios = new();
    

    [HttpGet("listar")]
    public ActionResult<List<Estadios>> Get() => _estadios;
    
    [HttpPost("adicionar")]
    public ActionResult<Estadios> Post([FromBody] Estadios estadio)
    {
        _estadios.Add(estadio);
        return CreatedAtAction(nameof(Get), new { id = estadio.Id }, estadio);
    }
    
}