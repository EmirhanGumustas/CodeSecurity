using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Shared.DataTransferObjects_DTO_
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        //buraya basketItemDTO'larını ekleyeceğiz . sepetin içindeki Kullanıcıları görmek istedigimiz için.
        public ApplicationUserDTO ApplicationUser { get; set; }
        public IEnumerable<BasketItemDTO> BasketItems { get; set; }
    }
}
