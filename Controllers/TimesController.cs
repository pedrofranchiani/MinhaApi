using MinhaApi.Models;

namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class TimesController : ControllerBase
{
    private static List<Times> _times = new();
    

    [HttpGet("listar")]
    public ActionResult<List<Times>> Get() => _times;
    
    [HttpPost("adicionar")]
    public ActionResult<Times> Post([FromBody] TimesDto dto)
    {
        var time = new Times
        {
            Nome = dto.Nome,
            Sigla = dto.Sigla,
            Estado = dto.Estado
        };
        _times.Add(time);
        return CreatedAtAction(nameof(Get), new { id = time.Id }, time);
    }

    [HttpPatch("atualizar/{id}")]
    public ActionResult<Times> Patch(Guid id, [FromBody] TimesDto dto)
    {
        var time = _times.FirstOrDefault(t => t.Id == id);
        if (time == null)
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(dto.Nome))
            time.Nome = dto.Nome;

        if (!string.IsNullOrEmpty(dto.Sigla))
            time.Sigla = dto.Sigla;

        if (!string.IsNullOrEmpty(dto.Estado))
            time.Estado = dto.Estado;

        return Ok(time);
    }

    [HttpDelete("deletar/{id}")]
    public ActionResult Delete(Guid id)
    {
        var time = _times.FirstOrDefault(t => t.Id == id);
        if (time == null)
        {
            return NotFound();
        }
        _times.Remove(time);
        return NoContent();
    }
    
}