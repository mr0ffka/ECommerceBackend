using ECommerce.Application.Models.Pager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Addresses.Queries.GetList
{
    public record GetListQuery(AddressFilterDto filter, Pager pager) : IRequest<PagedResult<AddressListDto>>;
}
