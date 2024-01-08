using ECommerce.Application.Contracts.Common;

namespace ECommerce.Application.Features.Addresses.Queries.GetList
{
    public class AddressFilterDto : IFilter
    {
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? StreetAddress { get; set; }
        public string? UserId { get; set; }
    }
}
