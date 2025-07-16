using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}