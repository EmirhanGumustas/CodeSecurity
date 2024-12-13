using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Shared.ViewModel
{
    public class JoinViewModel
    {
        public InvitationViewModel Invitation { get; set; }
        public List<ParticipantViewModel> Participants { get; set; }
        public int CountOfParticipants { get; set; }
        public ParticipantViewModel Participant { get; set; }
    }
}
