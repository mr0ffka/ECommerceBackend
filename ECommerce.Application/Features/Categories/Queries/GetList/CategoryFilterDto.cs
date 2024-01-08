using ECommerce.Application.Contracts.Common;

namespace ECommerce.Application.Features.Categories.Queries.GetList
{
    public class CategoryFilterDto : IFilter
    {
        public string? Name { get; set; }
    }
}
