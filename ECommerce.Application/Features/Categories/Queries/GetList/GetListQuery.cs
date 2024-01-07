using ECommerce.Application.Models.Pager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Categories.Queries.GetList
{
    public record GetListQuery(CategoryFilterDto filter, Pager pager) : IRequest<PagedResult<CategoryListDto>>;
}
