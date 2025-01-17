namespace ECFJanvier.Models
{
    public class EvenementParticipant
    {
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int EvenementId { get; set; }

        public Evenement Evenement { get; set; }
    }
}
