using ECommerce.Application.Contracts.Common;
using ECommerce.Application.Features.Categories.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetList
{
    public class ProductFilterDto : IFilter
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int? StockFrom { get; set; }
        public int? StockTo { get; set; }
        public List<long> CategoryIds { get; set; } = new List<long>();
    }
}
