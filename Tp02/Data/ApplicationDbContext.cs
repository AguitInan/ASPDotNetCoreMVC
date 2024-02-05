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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { Id = 1, Nom = "Electronique" },
                new Categorie { Id = 2, Nom = "Vêtement" },
                new Categorie { Id = 3, Nom = "Cuisine" }
            );

            modelBuilder.Entity<Produit>().HasData(
                new Produit
                {
                    Id = 1,
                    Nom = "Ecouteurs",
                    Description = "Bose",
                    Prix = 89.99M,
                    Quantite = 100,
                    CategorieId = 1,
                    ImageUrl = "url_to_image"
                },
                new Produit
                {
                    Id = 2,
                    Nom = "Sweater",
                    Description = "Nike",
                    Prix = 49.99M,
                    Quantite = 50,
                    CategorieId = 2,
                    ImageUrl = "url_to_image"
                },
                new Produit
                {
                    Id = 3,
                    Nom = "Blender",
                    Description = "Pour smoothies",
                    Prix = 29.99M,
                    Quantite = 80,
                    CategorieId = 3,
                    ImageUrl = "url_to_image"
                }
            );
        }
    }
}
