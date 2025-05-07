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
        public DbSet<Vartotojas> Vartotojai { get; set; }
        public DbSet<UserPostLikes> UserPostLikes {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<UserPostLikes>()
            .HasOne(ups => ups.Vartotojas)
            .WithMany(u => u.UserPostLikes)
            .HasForeignKey(ups => ups.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserPostLikes>()
            .HasOne(ups => ups.Automobilis)
            .WithMany(p => p.UserPostLikes)
            .HasForeignKey(ups => ups.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
    }
}
