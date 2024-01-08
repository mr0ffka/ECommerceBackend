namespace ECommerce.Application.Features.Addresses.Queries.GetById
{
    public class AddressDto
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
    }
}
