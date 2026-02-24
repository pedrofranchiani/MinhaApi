namespace MinhaApi.Controllers;

public class Times
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public string Sigla { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}