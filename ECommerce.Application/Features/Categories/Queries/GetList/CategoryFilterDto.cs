using ECommerce.Application.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Categories.Queries.GetList
{
    public class CategoryFilterDto : IFilter
    {
        public string? Name { get; set; }
    }
}
