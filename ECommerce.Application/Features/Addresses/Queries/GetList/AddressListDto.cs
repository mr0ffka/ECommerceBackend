using ECommerce.Application.Models.Identity;

namespace ECommerce.Application.Features.Addresses.Queries.GetList
{
    public class AddressListDto
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
        public UserDto User { get; set; }
    }
}
