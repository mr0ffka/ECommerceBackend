using MediatR;

namespace ECommerce.Application.Features.CartItems.Commands.Delete
{
    public class DeleteCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
