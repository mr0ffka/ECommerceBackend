using MediatR;

namespace ECommerce.Application.Features.Coupons.Commands.Create
{
    public class CreateCommand : IRequest<long>
    {
        public string Code { get; set; } = string.Empty;
        public DateTime ValidFromUtc { get; set; } = DateTime.UtcNow;
        public DateTime ValidToUtc { get; set; }
        public int Percentage { get; set; }
        public int? AvailableAmount { get; set; }
    }
}
