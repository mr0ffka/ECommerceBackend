﻿using AutoMapper;
using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Models.Identity;

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
}
