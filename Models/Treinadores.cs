namespace MinhaApi.Controllers;

public class Treinadores
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public int? Idade { get; set; } 
}