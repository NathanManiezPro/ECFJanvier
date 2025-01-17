using System.ComponentModel.DataAnnotations;

namespace ECFJanvier.Models
{
    public class Evenement
    {
        public int Id { get; set; }

        [Display(Name = "Titre")]
        [Required(ErrorMessage = "Titre Manquant")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Il ne faut pas dépasser les 20 caractères")]
        public string Titre { get; set; }
        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date Manquante")]
        public DateTime Date { get; set; }

        [Display(Name = "Lieu")]
        [Required(ErrorMessage = "Lieu Manquant")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Il ne faut pas dépasser les 50 caractères")]
        public string Lieu { get; set; }

        public List<EvenementParticipant>? Participants { get; set; } = new List<EvenementParticipant>();

    }
}
