using ECommerce.Application.Contracts.Persistence;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories
{
    public class ExampleRepository : GenericRepository<Example>, IExampleRepository
    {
        public ExampleRepository(ECommerceDbContext context) : base(context)
        {
        }

        public Task<List<Example>> GetAllExamples()
        {
            throw new NotImplementedException();
        }

        public Task<Example> GetExamples(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUnique(string name)
        {
            return !(await _context.Examples.AnyAsync(x => x.Name == name));
        }
    }
}
