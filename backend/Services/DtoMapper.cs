using AutoMapper;
using Core.Concrete;
using Core.Dtos;

namespace Services
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<LoginDto, User>().ReverseMap();
            CreateMap<TokenDto, UserToken>().ReverseMap();
            CreateMap<TicketDto, Ticket>().ReverseMap();
            CreateMap<TicketAddDto, Ticket>().ReverseMap();
            CreateMap<TicketUpdateDto, Ticket>().ReverseMap();
            CreateMap<TicketTypeAddDto, TicketType>().ReverseMap();
            CreateMap<TicketTypeUpdateDto, TicketType>().ReverseMap();
        }
    }
}
