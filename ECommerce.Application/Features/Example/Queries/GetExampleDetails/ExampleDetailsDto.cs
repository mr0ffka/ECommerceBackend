using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Example.Queries.GetExampleDetails
{
    public class ExampleDetailsDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
