using AutoMapper;
using Core.Concrete;
using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
        }
    }
}
