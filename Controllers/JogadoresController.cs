namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class JogadoresController : ControllerBase
{
    private static List<Jogadores> _jogadores = new();
    

    [HttpGet("listar")]
    public ActionResult<List<Jogadores>> Get() => _jogadores;
    
    [HttpPost("adicionar")]
    public ActionResult<Jogadores> Post([FromBody] Jogadores jogador)
    {
        _jogadores.Add(jogador);
        return CreatedAtAction(nameof(Get), new { id = jogador.Id }, jogador);
    }
}