using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetById
{
    public record GetByIdQuery(long Id) : IRequest<CategoryDto>;
}
