using AutoMapper;
using ECommerce.Business.Abstract;
using ECommers.Data.Abstrack;
using ECommers.Entity.Concrate;
using ECommers.Shared.DataTransferObjects_DTO_;
using ECommers.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrate
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO<BookDTO>> AddAsync(BookCreateDTO bookCreateDTO)
        {
            Book book = _mapper.Map<Book>(bookCreateDTO); // şuan bcd döndürdük booka.
            await _unitOfWork.GetRepository<Book>().AddAsync(book);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result <= 0)
            {
                return ResponseDTO<BookDTO>.Fail("  asdşads", StatusCodes.Status500InternalServerError);
            }
            BookDTO bookDTO = _mapper.Map<BookDTO>(book); //
            return ResponseDTO<BookDTO>.Success(bookDTO, StatusCodes.Status201Created);


        }

        public async Task<ResponseDTO<int>> CountAsync()
        {
            var x = await _unitOfWork.GetRepository<Book>().CountAsync();
            return ResponseDTO<int>.Success(x, StatusCodes.Status201Created);

        }

        public async Task<ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>> DeleteAsync(int id)
        {
            var book = await _unitOfWork.GetRepository<Book>().GetByIdAsync(id);
                         _unitOfWork.GetRepository<Book>().Delete(book);
            return ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>.Success(200);
        }

        public async Task<ResponseDTO<IEnumerable<BookDTO>>> GetAllAsync()
        {
            var x = await _unitOfWork.GetRepository<Book>().GetAllAsync();

            var y = _mapper.Map<IEnumerable<BookDTO>>(x);

            return ResponseDTO<IEnumerable<BookDTO>>.Success(y, 202);
        }

        public async Task<ResponseDTO<BookDTO>> GetAsync(int id)
        {
            var x = await _unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            var y = _mapper.Map<BookDTO>(x);
            return ResponseDTO<BookDTO>.Success(y,200);
        }

        public async Task<ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>> UpdateAsync(BookUptadeDTO bookUptadeDTO)
        {
            var book = await _unitOfWork.GetRepository<Book>().GetByIdAsync(bookUptadeDTO.Id);
            if (book == null)
            {
                return ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>.Fail("", 202);
            }
            var result = _mapper.Map<BookDTO>(book);
            await _unitOfWork.SaveChangeAsync();
            return ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>.Success(202);
        }
    }
}
