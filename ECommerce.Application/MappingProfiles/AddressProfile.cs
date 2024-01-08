using AutoMapper;
using ECommerce.Application.Features.Addresses.Commands.Create;
using ECommerce.Application.Features.Addresses.Commands.Update;
using ECommerce.Application.Features.Addresses.Queries.GetById;
using ECommerce.Application.Features.Addresses.Queries.GetList;
using ECommerce.Domain;

namespace ECommerce.Application.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile() 
        {
            CreateMap<AddressListDto, Address>()
                .ReverseMap()
                .ForMember(d => d.User, o => o.MapFrom<UserDtoByIdResolver, string>(s => s.UserId));

            CreateMap<Address, AddressDto>();

            CreateMap<CreateCommand, Address>()
                .ForMember(d => d.UserId, o => o.MapFrom<CurrentUserIdResolver, object>(s => s));

            CreateMap<UpdateCommand, Address>()
                .ForMember(d => d.UserId, o => o.MapFrom<CurrentUserIdResolver, object>(s => s));
        }
    }
}
