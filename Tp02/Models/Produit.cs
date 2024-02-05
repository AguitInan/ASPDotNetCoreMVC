using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tp02.Models;

namespace Tp02.Models
{
    [Table("produit")]
    public class Produit
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nom")]
        [Display(Name = "Nom du produit")]
        public string Nom { get; set; }
        [Column("description")]
        [Display(Name = "Description du produit")]
        public string Description { get; set; }
        [Column("prix")]
        [Display(Name = "Prix du produit")]
        public decimal Prix { get; set; }
        [Column("quantite")]
        [Display(Name = "Quantité")]

        public int Quantite { get; set; }
        [Column("image_url")]

        [Display(Name = "Image du produit")]
        public string ImageUrl { get; set; }
        [Column("categorie_id")]
        [Display(Name = "CatégorieId du produit")]
        public int CategorieId { get; set; }

        public Categorie Categories { get; set; }
    }
}
