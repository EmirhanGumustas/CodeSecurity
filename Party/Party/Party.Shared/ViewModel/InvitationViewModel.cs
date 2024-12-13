using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Shared.ViewModel
{
    public class InvitationViewModel
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        List<ParticipantViewModel> Participants { get; set; } // katılımcıların hangi partilerine gittiklerine görmek için
    }
}
