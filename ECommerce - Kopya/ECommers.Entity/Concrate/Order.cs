using ECommers.Entity.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Entity.Concrate
{
    public class Order : BaseEntity // sipariş
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }  // sipariş detayları
    }
}
