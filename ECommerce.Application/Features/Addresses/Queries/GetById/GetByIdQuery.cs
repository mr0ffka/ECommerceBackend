using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Addresses.Queries.GetById
{
    public record GetByIdQuery(long Id) : IRequest<AddressDto>;
}
