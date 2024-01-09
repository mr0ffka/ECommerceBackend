namespace ECommerce.Application.Features.Coupons.Queries.GetById
{
    public class CouponDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime ValidFromUtc { get; set; } = DateTime.UtcNow;
        public DateTime ValidToUtc { get; set; }
        public int Percentage { get; set; }
        public int? AvailableAmount { get; set; }
    }
}
