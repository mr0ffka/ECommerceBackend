using MediatR;

namespace ECommerce.Application.Features.Products.Commands.Create
{
    public class CreateCommand : IRequest<long>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public byte[]? ImageBase64Value { get; set; }
        public long CategoryId { get; set; }
    }
}
