using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Shared.DataTransferObjects_DTO_
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserDTO ApplicationUserDTO { get; set; }
        public IEnumerable<OrderItemDTO> OrderItems { get; set; }
    }
}
