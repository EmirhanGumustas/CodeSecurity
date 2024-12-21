using ECommers.Shared.DataTransferObjects_DTO_;
using ECommers.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseDTO<CategoryDTO>> GetAsync(int id);
        Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync();
        Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO);
        Task<ResponseDTO<NoContent>> UptadeAsync(CategoryUptadeDTO categoryUptadeDTO);
        Task<ResponseDTO<NoContent>> DeleteAsync(int categoryId);
        Task<ResponseDTO<int>> CountAsync(); // <ResponseDTO<int>> count sayısını bulmamız için fakat t yerine class dışında yazılmıyordu.Response zorunlu class olacaksın demediğimiz için yazılabilecekmiş

    }
}
