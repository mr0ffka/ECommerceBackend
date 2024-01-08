using ECommerce.Application.Contracts.Common;

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
