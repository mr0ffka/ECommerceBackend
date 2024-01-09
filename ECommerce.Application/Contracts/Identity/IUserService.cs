using ECommerce.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
