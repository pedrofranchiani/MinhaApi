namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")] 
public class TreinadoresController : ControllerBase
{
    private static List<Treinadores> _treinadores = new();
    

    [HttpGet("listar")]
    public ActionResult<List<Treinadores>> Get() => _treinadores;

    [HttpPost("adicionar")]
    public ActionResult<Treinadores> Post([FromBody] Treinadores treinador)
    {
        _treinadores.Add(treinador);
        return CreatedAtAction(nameof(Get), new { id = treinador.Id }, treinador);
    }
    
}


