using MinhaApi.Models;

namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class JogadoresController : ControllerBase
{
    private static List<Jogadores> _jogadores = new();
    

    [HttpGet("listar")]
    public ActionResult<List<Jogadores>> Get() => _jogadores;
    
    [HttpPost("adicionar")]
    public ActionResult<Jogadores> Post([FromBody] JogadoresDto dto)
    {
        var jogador = new Jogadores
        {
            Nome = dto.Nome,
            Time = dto.Time,
            Idade = dto.Idade
        };
        _jogadores.Add(jogador);
        return CreatedAtAction(nameof(Get), new { id = jogador.Id }, jogador);
    }

    [HttpPatch("atualizar/{id}")]
    public ActionResult<Jogadores> Patch(Guid id, [FromBody] JogadoresDto dto)
    {
        var jogador = _jogadores.FirstOrDefault(j => j.Id == id);
        if (jogador == null)
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(dto.Nome))
            jogador.Nome = dto.Nome;

        if (!string.IsNullOrEmpty(dto.Time))
            jogador.Time = dto.Time;

        if (dto.Idade != null)
            jogador.Idade = dto.Idade;

        return Ok(jogador);
    }

    [HttpDelete("deletar/{id}")]
    public ActionResult Delete(Guid id)
    {
        var jogador = _jogadores.FirstOrDefault(j => j.Id == id);
        if (jogador == null)
        {
            return NotFound();
        }
        _jogadores.Remove(jogador);
        return NoContent();
    }
}