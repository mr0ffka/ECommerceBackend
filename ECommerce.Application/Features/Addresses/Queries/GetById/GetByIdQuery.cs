using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetById
{
    public record GetByIdQuery(long Id) : IRequest<AddressDto>;
}
