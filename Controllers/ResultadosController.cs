using MinhaApi.Models;

namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ResultadosController : ControllerBase
{
    private static List<Resultados> _resultados = new();
    
    [HttpGet("listar")]
    public ActionResult<List<Resultados>> Get() => _resultados;
    
    [HttpPost("adicionar")]
    public ActionResult<Resultados> Post([FromBody] ResultadosDto dto)
    {
        var resultado = new Resultados
        {
            Titulo = dto.Titulo,
            Rodada = dto.Rodada,
            DataHora = dto.DataHora,
            Mandante = dto.Mandante,
            Resultado = dto.Resultado
        };
        _resultados.Add(resultado);
        return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado);
    }

    [HttpPatch("atualizar/{id}")]
    public ActionResult<Resultados> Patch(Guid id, [FromBody] ResultadosDto dto)
    {
        var resultado = _resultados.FirstOrDefault(r => r.Id == id);
        if (resultado == null)
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(dto.Titulo))
            resultado.Titulo = dto.Titulo;

        if (dto.Rodada > 0)
            resultado.Rodada = dto.Rodada;

        if (dto.DataHora != default)
            resultado.DataHora = dto.DataHora;

        if (!string.IsNullOrEmpty(dto.Mandante))
            resultado.Mandante = dto.Mandante;

        if (!string.IsNullOrEmpty(dto.Resultado))
            resultado.Resultado = dto.Resultado;

        return Ok(resultado);
    }

    [HttpDelete("deletar/{id}")]
    public ActionResult Delete(Guid id)
    {
        var resultado = _resultados.FirstOrDefault(r => r.Id == id);
        if (resultado == null)
        {
            return NotFound();
        }
        _resultados.Remove(resultado);
        return NoContent();
    }
}