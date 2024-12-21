using ECommers.Shared.DataTransferObjects_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    // data transfer object -DTO  
    public interface IBasketService // hangi operasyon lazımise servis kısmına yazılır.
    {
        //DTO TANIMLAMA entity çağirabilirdik fakat APInin entitylere ulaşmasını istemedigmiz için DTO (viewmodel) tanımlıyacağız.
        //DTO= VERİYİ DIŞARIYA TRANSFER VERİRKEN VEYA ALIRKEN VERİYİ TRANSFER ETMEK İSTEBİLEN CLASS'LARIMİ.
        
        Task<BasketDTO> GetBasketAsync(int id); // kutulama işlemi yapacagız. = RESPONSE DTO'YA YAZIYORUZ.
        Task<IEnumerable<BasketDTO>> GetBasketsAsync();

    }
}
