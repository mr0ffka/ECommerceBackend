using MediatR;

namespace ECommerce.Application.Features.Addresses.Commands.Update
{
    public class UpdateCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
    }
}
