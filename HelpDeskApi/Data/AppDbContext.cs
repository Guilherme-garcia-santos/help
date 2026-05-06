using Microsoft.EntityFrameworkCore;
using HelpDeskApi.Models;

namespace HelpDeskApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Esta linha avisa o Entity Framework que 'Categoria' vai virar uma tabela
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Custo> Custos { get; set; }
    }
}