using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.Delete
{
    public class DeleteCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
