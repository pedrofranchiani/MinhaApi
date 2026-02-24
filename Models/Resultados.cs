namespace MinhaApi.Controllers;

public class Resultados
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public string Titulo { get; set; } = string.Empty;
    public int Rodada { get; set; }
    public DateTime DataHora { get; set; }
    public string Mandante { get; set; } =  string.Empty;
    public string Resultado { get; set; } =  string.Empty; // Mandante X Não mandante
}