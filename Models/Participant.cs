using System.ComponentModel.DataAnnotations;

namespace ECFJanvier.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Nom Manquant")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Il ne faut pas dépasser les 15 caractères")]
        public string Nom { get; set; }
        [Display(Name = "Prenom")]
        [Required(ErrorMessage = "Prenom Manquant")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Il ne faut pas dépasser les 15 caractères")]
        public string Prenom { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Manquant")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Il ne faut pas dépasser les 40 caractères")]
        public string Email { get; set; }

        public List<EvenementParticipant>? Evenements { get; set; } = new List<EvenementParticipant>();

    }
}
