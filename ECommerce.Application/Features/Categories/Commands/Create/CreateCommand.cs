using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Categories.Commands.Create
{
    public class CreateCommand : IRequest<long>
    {
        public string Name { get; set; } = string.Empty;
    }
}
