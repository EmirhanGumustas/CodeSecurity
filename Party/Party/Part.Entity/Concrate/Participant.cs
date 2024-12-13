using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part.Entity.Concrate
{
    public class Participant : IBaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte? Age { get; set; }
        public int NumberOfPeople { get; set; }
        public ICollection<InvitationParticipant> InvitationParticipants { get; set; }
    }
}
