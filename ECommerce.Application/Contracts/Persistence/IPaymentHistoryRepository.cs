using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IPaymentHistoryRepository : IGenericRepository<PaymentHistory>
    {
        //Task<List<Payment>> GetListAsync(ProductFilterDto filter, IPager pager);
        Task<PaymentHistory?> GetAsync(long id);
        //Task<List<PaymentHistory>> GetListAsync();
        //Task<bool> HasUniqueName(string name);
    }
}
