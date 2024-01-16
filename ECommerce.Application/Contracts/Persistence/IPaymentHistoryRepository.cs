using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IPaymentHistoryRepository : IGenericRepository<PaymentHistory>
    {
        Task<PaymentHistory?> GetAsync(long id);
    }
}
