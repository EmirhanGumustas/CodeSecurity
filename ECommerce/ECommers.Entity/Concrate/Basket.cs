using ECommers.Entity.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Entity.Concrate
{
    public class Basket :BaseEntity  // sepet
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}
