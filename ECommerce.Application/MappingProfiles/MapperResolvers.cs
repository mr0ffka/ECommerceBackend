using AutoMapper;
using ECommerce.Application.Contracts.Files;
using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Coupons.Queries.GetByCode;
using ECommerce.Application.Models.Identity;
using ECommerce.Application.Models.Simple.File;
using ECommerce.Domain;
using Microsoft.AspNetCore.Mvc;

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

    #region FileUrlResolver
    public class FileUrlResolver : IMemberValueResolver<object, object, Product, FileUrlDto>
    {
        private readonly IFileRepository _fileRepository;

        public FileUrlResolver(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public FileUrlDto Resolve(object source, object destination, Product sourceMember, FileUrlDto destMember, ResolutionContext context)
        {
            var fileUrl = new FileUrlDto();
            if (sourceMember.ThumbnailId.HasValue)
            {
                var file = _fileRepository.GetByIdAsync((long)sourceMember.ThumbnailId).GetAwaiter().GetResult();

                fileUrl.Id = file.Id;
                fileUrl.Url = file.Path.Substring(3);
            }
            return fileUrl;
        }
    }
    #endregion
}
