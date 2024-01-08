using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Update
{
    public class UpdateCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
