using ECommerce.Application.Extensions;
using ECommerce.Application.Features.Products.Queries.Get;
using ECommerce.Application.Models.Pager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetList
{
    public record GetListQuery(ProductFilterDto filter, Pager pager) : IRequest<PagedResult<ProductDto>>;
}
