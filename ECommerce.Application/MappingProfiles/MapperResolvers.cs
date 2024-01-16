using AutoMapper;
using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Coupons.Queries.GetByCode;
using ECommerce.Application.Models.Identity;
using ECommerce.Domain;

namespace ECommerce.Application.MappingProfiles
{
    #region CurrentUserIdResolver
    public class CurrentUserIdResolver : IMemberValueResolver<object, object, object, string>
    {
        private readonly IUserService _userService;

        public CurrentUserIdResolver(IUserService userService)
        {
            _userService = userService;
        }

        public string Resolve(object source, object destination, object sourceMember, string destMember, ResolutionContext context)
        {
            return _userService.CurrUserId;
        }
    }
    #endregion

    #region UserDtoByIdResolver
    public class UserDtoByIdResolver : IMemberValueResolver<object, object, string, UserDto>
    {
        private readonly IUserService _userService;

        public UserDtoByIdResolver(IUserService userService)
        {
            _userService = userService;
        }

        public UserDto Resolve(object source, object destination, string sourceMember, UserDto destMember, ResolutionContext context)
        {
            return _userService.GetUserAsync(sourceMember).GetAwaiter().GetResult();
        }
    }
    #endregion

    #region IsCouponValidResolver
    public class IsCouponValidResolver : IMemberValueResolver<object, object, Coupon, bool>
    {
        private readonly IUserService _userService;
        private readonly IUserCouponRepository _userCouponRepository;
        public IsCouponValidResolver(IUserService userService, IUserCouponRepository userCouponRepository) 
        {
            _userService = userService;
            _userCouponRepository = userCouponRepository;
        }

        public bool Resolve(object source, object destination, Coupon sourceMember, bool destMember, ResolutionContext context)
        {
            return _userCouponRepository.IsValidForUser(sourceMember.Code, _userService.CurrUserId).GetAwaiter().GetResult();
        }
    }
    #endregion
}
