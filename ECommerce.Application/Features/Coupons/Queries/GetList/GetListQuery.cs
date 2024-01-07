using ECommerce.Application.Models.Pager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Coupons.Queries.GetList
{
    public record GetListQuery(CouponFilterDto filter, Pager pager) : IRequest<PagedResult<CouponListDto>>;
}
