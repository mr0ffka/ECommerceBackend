using ECommerce.Application.Models.Identity;

namespace ECommerce.Application.Contracts.Identity
{
    public interface IUserService
    {
        public string CurrUserId { get; }
        public bool IsCurrUserAdmin { get; }
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserAsync(string id);
    }
}
