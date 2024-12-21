using Azure;
using ECommers.Shared.DataTransferObjects_DTO_;
using ECommers.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IBookService
    {
        Task<ResponseDTO<BookDTO>> GetAsync(int id);
        Task<ResponseDTO<IEnumerable<BookDTO>>> GetAllAsync();
        Task<ResponseDTO<BookDTO>> AddAsync(BookCreateDTO bookCreateDTO);
        Task<ResponseDTO<NoContent>> UpdateAsync(BookUptadeDTO bookUptadeDTO);
       
        Task<ResponseDTO<int>> CountAsync();
        Task<ResponseDTO<NoContent>> DeleteAsync(int id);
    }
}
