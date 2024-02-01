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
            modelBuilder.Entity<Marmoset>().HasData(
                new Marmoset { Id = 1, Name = "Marmoset1", Color = MarmosetColor.Bleu },
                new Marmoset { Id = 2, Name = "Marmoset2", Color = MarmosetColor.Rouge }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}

