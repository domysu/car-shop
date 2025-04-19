using Microsoft.EntityFrameworkCore;
using AutomobiliuPardavimoPrograma.Models;

namespace AutomobiliuPardavimoPrograma.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tavo DB lentelės (modeliai)
        public DbSet<Automobilis> Automobiliai { get; set; }
    }
}
