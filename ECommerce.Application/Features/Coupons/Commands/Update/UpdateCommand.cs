using MediatR;

namespace ECommerce.Application.Features.Coupons.Commands.Update
{
    public class UpdateCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime ValidFromUtc { get; set; } = DateTime.UtcNow;
        public DateTime ValidToUtc { get; set; }
        public int Percentage { get; set; }
    }
}
