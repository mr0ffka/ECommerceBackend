using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Create
{
    public class CreateCommand : IRequest<long>
    {
        public string Name { get; set; } = string.Empty;
    }
}
