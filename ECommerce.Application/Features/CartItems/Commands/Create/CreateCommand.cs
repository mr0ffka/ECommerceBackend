using MediatR;

namespace ECommerce.Application.Features.CartItems.Commands.Create
{
    public class CreateCommand : IRequest<long>
    {
        public int Quantity { get; set; }
        public long ProductId { get; set; }
    }
}
