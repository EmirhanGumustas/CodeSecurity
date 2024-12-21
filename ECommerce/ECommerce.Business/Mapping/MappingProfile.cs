using AutoMapper;
using ECommers.Entity.Concrate;
using ECommers.Shared.DataTransferObjects_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() // pg.cs'e kayıdını yapmak zorundasın ihtiyaç halinde çağirilması gerekecek
        {
            CreateMap<Category,CategoryDTO>().ReverseMap(); // tersinede çevirebilirsin.
            CreateMap<Category,CategoryCreateDTO>().ReverseMap();
            CreateMap<Category,CategoryUptadeDTO>().ReverseMap();
        }
    }
}
