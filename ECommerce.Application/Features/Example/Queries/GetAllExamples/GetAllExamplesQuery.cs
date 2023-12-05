using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Example.Queries.GetAllExample
{
    public record GetAllExamplesQuery : IRequest<List<ExampleDto>>;
}
