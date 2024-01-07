using ECommerce.Application.Features.Products.Queries.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.Get
{
    public record GetQuery(long Id) : IRequest<ProductDetailsDto>;
}
