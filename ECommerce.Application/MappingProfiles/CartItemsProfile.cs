using AutoMapper;
using ECommerce.Application.Features.CartItems.Commands.Create;
using ECommerce.Application.Features.CartItems.Commands.Update;
using ECommerce.Application.Features.CartItems.Queries.GetById;
using ECommerce.Application.Features.CartItems.Queries.GetList;
using ECommerce.Domain;

namespace ECommerce.Application.MappingProfiles
{
    public class CartItemsProfile : Profile
    {
        public CartItemsProfile() 
        {
            CreateMap<CartItem, CartItemListDto>();

            CreateMap<CartItem, CartItemDto>()
                .ForMember(d => d.User, o => o.MapFrom<UserDtoByIdResolver, string>(s => s.UserId));

            CreateMap<CreateCommand, CartItem>()
                .ForMember(d => d.UserId, o => o.MapFrom<CurrentUserIdResolver, object>(s => s));

            CreateMap<UpdateCommand, CartItem>()
                .ForMember(d => d.UserId, o => o.MapFrom<CurrentUserIdResolver, object>(s => s));
        }
    }
}
