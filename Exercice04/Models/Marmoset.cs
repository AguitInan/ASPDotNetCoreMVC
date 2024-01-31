using System.ComponentModel.DataAnnotations;

namespace Exercice04.Models
{
    public class Marmoset
    {
        public int Id { get; set; }
        [Display(Name = "Nom")]
        public string? Name { get; set; }
        [Display(Name = "Couleur")]
        public MarmosetColor? Color { get; set; }

        public enum MarmosetColor
        {
            Rouge,
            Bleu,
            Vert,
            Jaune,
            Violet,
            Blanc,
            Noir
        }

    }
}
