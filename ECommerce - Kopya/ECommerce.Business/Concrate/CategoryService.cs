using AutoMapper;
using ECommerce.Business.Abstract;
using ECommers.Data.Abstrack;
using ECommers.Entity.Concrate;
using ECommers.Shared.DataTransferObjects_DTO_;
using ECommers.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrate
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO)
        {
            var build = _mapper.Map<Category>(categoryCreateDTO);
            await _unitOfWork.GetRepository<Category>().AddAsync(build);
            await _unitOfWork.SaveChangeAsync();

            var x = _mapper.Map<CategoryDTO>(build);
            return ResponseDTO<CategoryDTO>.Success(x, 201);


        }

        public async Task<ResponseDTO<int>> CountAsync()
        {
            await _unitOfWork.GetRepository<CategoryDTO>().CountAsync();
            return ResponseDTO<int>.Success(201);

        }

        public async Task<ResponseDTO<NoContent>> DeleteAsync(int categoryId)
        {
            var x = await _unitOfWork.GetRepository<Category>().GetByIdAsync(categoryId);
            _unitOfWork.GetRepository<Category>().Delete(x);
            await _unitOfWork.SaveChangeAsync();
            return ResponseDTO<NoContent>.Success(201);
        }

        public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync()
        {
            var x = await _unitOfWork.GetRepository<Category>().GetAllAsync();
            var y = _mapper.Map<IEnumerable<CategoryDTO>>(x);
            return ResponseDTO<IEnumerable<CategoryDTO>>.Success(y, 201);
        }

        public async Task<ResponseDTO<CategoryDTO>> GetAsync(int id)
        {
            var y = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            var x = _mapper.Map<CategoryDTO>(y);
            return ResponseDTO<CategoryDTO>.Success(x, 201);
        }

        public async Task<ResponseDTO<NoContent>> UptadeAsync(CategoryUptadeDTO categoryUptadeDTO)
        {
            var x = await _unitOfWork.GetRepository<Category>().GetByIdAsync(categoryUptadeDTO.Id);
            _unitOfWork.GetRepository<Category>().Update(x);
            _mapper.Map(categoryUptadeDTO, x);
            await _unitOfWork.SaveChangeAsync();
            return ResponseDTO<NoContent>.Success(500);
        }
    }
}
