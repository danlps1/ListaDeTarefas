using ListaDeTarefas.Domin.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<TarefaModel> Tarefas { get; set; }
}