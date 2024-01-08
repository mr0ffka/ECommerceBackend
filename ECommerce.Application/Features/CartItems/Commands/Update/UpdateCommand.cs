using MediatR;

namespace ECommerce.Application.Features.CartItems.Commands.Update
{
    public class UpdateCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
    }
}
