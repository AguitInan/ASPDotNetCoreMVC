using System.ComponentModel.DataAnnotations.Schema;
using Tp02.Models;

namespace Tp02.Models
{
    [Table("categorie")]
    public class Categorie
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nom")]
        public string Nom { get; set; }
        public List<Produit> Produits { get; set; }
    }
}
