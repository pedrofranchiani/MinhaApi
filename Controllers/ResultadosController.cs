namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ResultadosController : ControllerBase
{
    private static List<Resultados> _Resultados = new();
    
    [HttpGet("listar")]
    public ActionResult<List<Resultados>> Get() => _Resultados;
    
    [HttpPost("adicionar")]
    public ActionResult<Resultados> Post([FromBody] Resultados resultado)
    
    {
        _Resultados.Add(resultado);
        return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado);
    }
}