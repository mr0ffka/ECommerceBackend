using AutoMapper;
using ECommerce.Application.Features.Coupons.Commands.Update;
using ECommerce.Application.Features.Coupons.Commands.Create;
using ECommerce.Application.Features.Coupons.Queries.GetList;
using ECommerce.Domain;
using ECommerce.Application.Features.Coupons.Queries.GetById;

namespace ECommerce.Application.MappingProfiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile() 
        {
            CreateMap<CouponListDto, Coupon>().ReverseMap();
            CreateMap<Coupon, CouponDto>();
            CreateMap<CreateCommand, Coupon>();
            CreateMap<UpdateCommand, Coupon>();
        }
    }
}
