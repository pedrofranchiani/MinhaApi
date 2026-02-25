namespace MinhaApi.DTOs;

public class ResultadosDto
{
    public string Titulo { get; set; } = string.Empty;
    public int Rodada { get; set; }
    public DateTime DataHora { get; set; }
    public string Mandante { get; set; } = string.Empty;
    public string Resultado { get; set; } = string.Empty;
}
