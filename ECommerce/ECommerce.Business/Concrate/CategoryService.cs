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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO) //CategoryCreateDTO = category çeviricez. // sonra CategoryDTO çeviricez.
        {
            Category category = _mapper.Map<Category>(categoryCreateDTO); // dönüştüremek istenen hedef ilk yazılan yeşil ise CategoryCreateDTO yazılır.
            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            var result =  await _unitOfWork.SaveChangeAsync();

            if (result<=0) // kayıt gerçekleşmemişse
            {
                return ResponseDTO<CategoryDTO>.Fail("Bir Hata Oluştu",500);
            }
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
            return ResponseDTO<CategoryDTO>.Success(categoryDTO, 201);


        }

        public Task<ResponseDTO<int>> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<NoContent>> DeleteAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync() // categoryDTO dönmemiz gereki
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(); // databaseden çektik category

            if (categories==null) // null olma durumu veri olmama durumu
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Server'da bir hata oluştu sonra tekrar deneyiniz", StatusCodes.Status500InternalServerError);
            }

            if (categories.Count() == 0) // [] böyle gelmişse
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Hiç Kategori Bulunamadı", StatusCodes.Status404NotFound); // hatası statuscodes olarak yazarak görebiliriz.

            }

            var categoryDTOs= _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return ResponseDTO<IEnumerable<CategoryDTO>>.Success(categoryDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<CategoryDTO>> GetAsync(int id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);// ilgili kayıdı bulamazsa null döndurur onun kontrolunu yapıyoruz.
            if (category == null)
            {
                return ResponseDTO<CategoryDTO>.Fail("Böyle kategori bulnamadı",404);
            }
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return ResponseDTO<CategoryDTO>.Success(categoryDTO, StatusCodes.Status200OK);
        }

        public Task<ResponseDTO<NoContent>> UptadeAsync(CategoryUptadeDTO categoryUptadeDTO)
        {
            throw new NotImplementedException();
        }
    }
}
