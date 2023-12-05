using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Example.Commands.DeleteExample
{
    public class DeleteExampleCommand : IRequest<Unit>
    {
        public string Id { get; set; } = string.Empty;
    }
}
