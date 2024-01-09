using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<Payment?> GetAsync(long id)
        {
            return await _context.Payments
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
