﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tp02.Data;

#nullable disable

namespace Tp02.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tp02.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nom");

                    b.HasKey("Id");

                    b.ToTable("categorie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nom = "Electronique"
                        },
                        new
                        {
                            Id = 2,
                            Nom = "Vêtement"
                        },
                        new
                        {
                            Id = 3,
                            Nom = "Cuisine"
                        });
                });

            modelBuilder.Entity("Tp02.Models.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int")
                        .HasColumnName("categorie_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_url");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nom");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("prix");

                    b.Property<int>("Quantite")
                        .HasColumnType("int")
                        .HasColumnName("quantite");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("produit");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategorieId = 1,
                            Description = "Bose",
                            ImageUrl = "url_to_image",
                            Nom = "Ecouteurs",
                            Prix = 89.99m,
                            Quantite = 100
                        },
                        new
                        {
                            Id = 2,
                            CategorieId = 2,
                            Description = "Nike",
                            ImageUrl = "url_to_image",
                            Nom = "Sweater",
                            Prix = 49.99m,
                            Quantite = 50
                        },
                        new
                        {
                            Id = 3,
                            CategorieId = 3,
                            Description = "Pour smoothies",
                            ImageUrl = "url_to_image",
                            Nom = "Blender",
                            Prix = 29.99m,
                            Quantite = 80
                        });
                });

            modelBuilder.Entity("Tp02.Models.Produit", b =>
                {
                    b.HasOne("Tp02.Models.Categorie", "Categories")
                        .WithMany("Produits")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Tp02.Models.Categorie", b =>
                {
                    b.Navigation("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}
