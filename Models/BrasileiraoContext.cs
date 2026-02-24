using Microsoft.EntityFrameworkCore;
using MinhaApi.Controllers;
using MinhaApi.Models;

namespace MinhaApi.Models;

public class BrasileiraoContext : DbContext
{
    public DbSet<Jogadores> Jogadores { get; set; }
    public DbSet<Times>  Times { get; set; }
    public DbSet<Estadios> Estadios { get; set; }
    public DbSet<Resultados> Resultados { get; set; }
    public DbSet<Treinadores> Treinadores { get; set; }
    
}