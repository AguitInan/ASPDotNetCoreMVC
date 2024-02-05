using Microsoft.EntityFrameworkCore;
using Tp02.Models;

namespace Tp02.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\demo01ado;Database=caisse_enregistreuse;Trusted_Connection=True;");
        }
        
    }
}
