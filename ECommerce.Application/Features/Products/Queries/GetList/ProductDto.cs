using ECommerce.Application.Features.Categories.Queries.GetById;

namespace ECommerce.Application.Features.Products.Queries.GetList;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[]? ImageBase64Value { get; set; }
    public CategoryDto Category { get; set; }
}
