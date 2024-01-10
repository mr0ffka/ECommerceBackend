using ECommerce.Application.Contracts.Persistence;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class PaymentHistoryRepository : GenericRepository<PaymentHistory>, IPaymentHistoryRepository
    {
        public PaymentHistoryRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<PaymentHistory?> GetAsync(long id)
        {
            return await _context.PaymentHistory
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
