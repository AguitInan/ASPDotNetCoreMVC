using Exercice04.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static Exercice04.Models.Marmoset;

namespace Exercice04.Data
{
    public class MarmosetDbContext : DbContext
    {
        public DbSet<Marmoset> Marmosets { get; set; }
        public MarmosetDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\demo01ado;Database=Marmoset;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int _lastId = 0; // pour faire un équivalent d'IDENTITY ou AUTO INCREMENT

            modelBuilder.Entity<Marmoset>().HasData(
                    new Marmoset { Id = ++_lastId, Name = "Marmoset1", Color = MarmosetColor.Bleu },
                    new Marmoset { Id = ++_lastId, Name = "Marmoset2", Color = MarmosetColor.Rouge }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}

