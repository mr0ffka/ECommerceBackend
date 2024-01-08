using MediatR;

namespace ECommerce.Application.Features.Coupons.Commands.Delete
{
    public class DeleteCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
