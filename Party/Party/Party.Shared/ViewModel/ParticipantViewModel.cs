using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Shared.ViewModel
{
    public class ParticipantViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte? Age { get; set; }
        public int NumberOfPeople { get; set; }
        public ICollection<InvitationViewModel> InvitationViewModels { get; set; }
    }
}
