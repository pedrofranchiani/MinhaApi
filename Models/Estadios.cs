namespace MinhaApi.Controllers;

public class Estadios
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string? Dono { get; set; }
}