using MinhaApi.Models;

namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.DTOs;

[ApiController]
[Route("api/[controller]")] 
public class TreinadoresController : ControllerBase
{
    private static List<Treinadores> _treinadores = new();
    

    [HttpGet("listar")]
    public ActionResult<List<Treinadores>> Get() => _treinadores;

    [HttpPost("adicionar")]
    public ActionResult<Treinadores> Post([FromBody] TreinadoresDto dto)
    {
        var treinador = new Treinadores
        {
            Nome = dto.Nome,
            Time = dto.Time,
            Idade = dto.Idade
        };
        _treinadores.Add(treinador);
        return CreatedAtAction(nameof(Get), new { id = treinador.Id }, treinador);
    }

    [HttpPatch("atualizar/{id}")]
    public ActionResult<Treinadores> Patch(Guid id, [FromBody] TreinadoresDto dto)
    {
        var treinador = _treinadores.FirstOrDefault(t => t.Id == id);
        if (treinador == null)
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(dto.Nome))
            treinador.Nome = dto.Nome;

        if (!string.IsNullOrEmpty(dto.Time))
            treinador.Time = dto.Time;

        if (dto.Idade != null)
            treinador.Idade = dto.Idade;

        return Ok(treinador);
    }

    [HttpDelete("deletar/{id}")]
    public ActionResult Delete(Guid id)
    {
        var treinador = _treinadores.FirstOrDefault(t => t.Id == id);
        if (treinador == null)
        {
            return NotFound();
        }
        _treinadores.Remove(treinador);
        return NoContent();
    }
    
}
