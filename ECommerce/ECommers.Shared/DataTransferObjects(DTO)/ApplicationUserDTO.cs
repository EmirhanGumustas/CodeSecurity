using ECommers.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Shared.DataTransferObjects_DTO_
{
    public class ApplicationUserDTO
    {
        public string firstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public GenderType Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
