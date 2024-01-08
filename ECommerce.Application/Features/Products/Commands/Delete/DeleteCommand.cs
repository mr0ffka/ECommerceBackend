using MediatR;

namespace ECommerce.Application.Features.Products.Commands.Delete
{
    public class DeleteCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
