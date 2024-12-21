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
            Book book = _mapper.Map<Book>(bookCreateDTO); // neden booka döndürdük - verilerimiz book türünden 
            await _unitOfWork.GetRepository<Book>().AddAsync(book);
            var result = await _unitOfWork.SaveChangeAsync();

            if (result <= 0) { return ResponseDTO<BookDTO>.Fail("kayıt yok", 500); }

            var bookDTO = _mapper.Map<BookDTO>(book); //kullanıcıya göndermek istedigim BookDTO oldugu için çevirme işlemi yapıyorum.
            return ResponseDTO<BookDTO>.Success(bookDTO, 201);
        }

        public async Task<ResponseDTO<int>> CountAsync()
        {
          var x =  await _unitOfWork.GetRepository<Book>().CountAsync();
            return ResponseDTO<int>.Success(x,200);
        }

        public async Task<ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>> DeleteAsync(int id)
        {
            var x = await _unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            _unitOfWork.GetRepository<Book>().Delete(x);
            var y = await _unitOfWork.SaveChangeAsync();
            return ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>.Success(201);


        }

        public async Task<ResponseDTO<IEnumerable<BookDTO>>> GetAllAsync()
        {

            var x = await _unitOfWork.GetRepository<Book>().GetAllAsync(); // veriler book türünden oldugu için book yazdık
            if (x == null)
            {
                return ResponseDTO<IEnumerable<BookDTO>>.Fail("hata", 500);
            }
            if (x.Count() == 0)
            {
                return ResponseDTO<IEnumerable<BookDTO>>.Fail("hatalı", 500);
            }
            var bookDto = _mapper.Map<IEnumerable<BookDTO>>(x); // liste istedigim için liste şeklinde göndermem gerekiyor

            return ResponseDTO<IEnumerable<BookDTO>>.Success(bookDto, 201);// ama verileri yansıtırken bookdto olması gerekir.
        }

        public async Task<ResponseDTO<BookDTO>> GetAsync(int id)
        {
            var y = await _unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            var x = _mapper.Map<BookDTO>(y);
            return ResponseDTO<BookDTO>.Success(x, 401);
        }

        public async Task<ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>> UpdateAsync(BookUptadeDTO bookUptadeDTO)
        {

            var x = await _unitOfWork.GetRepository<Book>().GetByIdAsync(bookUptadeDTO.Id); //gelen verinin ıdsı yakaladık. 
            if (x == null)
            {
                return ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>.Fail("yok böyle kayıt", 404);
            }
            _mapper.Map(bookUptadeDTO, x); // 
            _unitOfWork.GetRepository<Book>().Update(x);

            await _unitOfWork.SaveChangeAsync();

            return ResponseDTO<ECommers.Shared.ResponseDTOs.NoContent>.Success(StatusCodes.Status200OK);
        }
    }
}
