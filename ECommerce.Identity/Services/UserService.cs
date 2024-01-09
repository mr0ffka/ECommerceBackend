using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Models.Identity;
using ECommerce.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ECommerce.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;


        public UserService(
            UserManager<AppUser> userManager,
            IHttpContextAccessor contextAccessor
        )
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string CurrUserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }
        public bool IsCurrUserAdmin { get => _contextAccessor.HttpContext?.User?.IsInRole("Administrator") ?? false; }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
            }).ToList();
        }
    }
}
