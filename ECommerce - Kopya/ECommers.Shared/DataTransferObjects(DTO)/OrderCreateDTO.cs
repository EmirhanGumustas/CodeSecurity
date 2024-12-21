using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Shared.DataTransferObjects_DTO_
{
    public class OrderCreateDTO
    {
        public string ApplicationUserId { get; set; }
        public IEnumerable<OrderItemCreateDTO> OrderItems { get; set; } // sipariş verirken created

    }
}
