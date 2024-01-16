using AutoMapper;
using ECommerce.Application.Features.Coupons.Commands.Update;
using ECommerce.Application.Features.Coupons.Commands.Create;
using ECommerce.Application.Features.Coupons.Queries.GetList;
using ECommerce.Domain;

namespace ECommerce.Application.MappingProfiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile() 
        {
            CreateMap<CouponListDto, Coupon>()
                .ReverseMap();

            CreateMap<Coupon, Features.Coupons.Queries.GetById.CouponDto>();

            CreateMap<Coupon, Features.Coupons.Queries.GetByCode.CouponDto>()
                .ForMember(d => d.IsValid, o => o.MapFrom<IsCouponValidResolver, Coupon>(s => s));

            CreateMap<CreateCommand, Coupon>();

            CreateMap<UpdateCommand, Coupon>();
        }
    }
}
