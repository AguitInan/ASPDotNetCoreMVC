using System.ComponentModel.DataAnnotations;

namespace Tp01.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Display(Name = "Titre de la tâche")]
        public string Title { get; set; }
        [Display(Name = "Description de la tâche")]
        public string Description { get; set; }
        [Display(Name = "Statut de la tâche")]
        public bool IsCompleted { get; set; }
    }
}
