using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repo
{
    public class HeroiContext : DbContext
    {
        // Construtor para aceitar nossa coneção
        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options)
        {
        }

        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        // Heroi Batalha tem uma Chave composta
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            });
        }
    }
}
