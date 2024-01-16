namespace ECommerce.Application.Features.Coupons.Queries.GetByCode
{
    public class CouponDto
    {
        public string Code { get; set; }
        public int Percentage { get; set; }
        public bool IsValid { get; set; }
    }
}
