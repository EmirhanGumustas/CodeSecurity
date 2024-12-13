namespace Part.Entity.Concrate
{
    public class Invitation : IBaseEntity
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public ICollection<InvitationParticipant> InvitationParticipants { get; set; }
    }
}
