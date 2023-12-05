using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IExampleRepository : IGenericRepository<Example>
    {
        Task<Example> GetExamples(string id);
        Task<List<Example>> GetAllExamples();
        Task<bool> IsUnique(string name);
    }
}
