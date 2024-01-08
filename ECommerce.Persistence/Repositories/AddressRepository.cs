using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Addresses.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<Address?> GetAsync(long id)
        {
            return await _context.Addresses
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Address>> GetListAsync(AddressFilterDto filter, IPager pager)
        {
            var predicate = PredicateBuilder.New<Address>(true);

            if (!string.IsNullOrEmpty(filter.Country))
            {
                predicate.And(x => x.Country.ToLower().Contains(filter.Country.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Region))
            {
                predicate.And(x => x.Region.ToLower().Contains(filter.Region.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.City))
            {
                predicate.And(x => x.City.ToLower().Contains(filter.City.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.ZipCode))
            {
                predicate.And(x => x.ZipCode.ToLower().Contains(filter.ZipCode.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.StreetAddress))
            {
                predicate.And(x => x.StreetAddress.ToLower().Contains(filter.StreetAddress.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.UserId))
            {
                predicate.And(x => x.UserId.ToLower().Contains(filter.UserId.ToLower()));
            }

            return await _context.Addresses
                .AsNoTracking()
                .Where(predicate)
                .PaginateData(pager)
                .ToListAsync();
        }
    }
}
