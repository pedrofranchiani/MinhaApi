using MinhaApi.Models;

namespace MinhaApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class EstadiosController : ControllerBase
{
    private static List<Estadios> _estadios = new();
    

    [HttpGet("listar")]
    public ActionResult<List<Estadios>> Get() => _estadios;
    
    [HttpPost("adicionar")]
    public ActionResult<Estadios> Post([FromBody] EstadiosDto dto)
    {
        var estadio = new Estadios
        {
            Nome = dto.Nome,
            Estado = dto.Estado,
            Dono = dto.Dono
        };
        _estadios.Add(estadio);
        return CreatedAtAction(nameof(Get), new { id = estadio.Id }, estadio);
    }
    
    
    [HttpPatch(template:"atualizar/{id}")]
    public ActionResult<Estadios> Patch(Guid id, [FromBody] EstadiosDto dto)
    {
        var estadio = _estadios.FirstOrDefault(e => e.Id == id);
        if (estadio == null)
        {
            return NotFound();
        }
        
        if (!string.IsNullOrEmpty(dto.Nome))
            estadio.Nome = dto.Nome;
    
        if (!string.IsNullOrEmpty(dto.Estado))
            estadio.Estado = dto.Estado;
    
        if (!string.IsNullOrEmpty(dto.Dono))
            estadio.Dono = dto.Dono;
    
        return Ok(estadio);
    }
    
    [HttpDelete("deletar/{id}")]
    public ActionResult Delete(Guid id)
    {
        var estadio = _estadios.FirstOrDefault(e => e.Id == id);
        if (estadio == null)
        {
            return NotFound();
        }
        _estadios.Remove(estadio);
        return NoContent();
    }
}