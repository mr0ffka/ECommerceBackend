using ECommerce.Application.Features.Addresses.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<List<Address>> GetListAsync(AddressFilterDto filter, IPager pager);
        Task<Address?> GetAsync(long id);
    }
}
