using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Extensions;
using ECommerce.Application.Models.Common;
using ECommerce.Domain.Enumerations.Payments;
using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.GetPaymentStatusList;

public class GetPaymentStatusListQueryHandler : IRequestHandler<GetPaymentStatusListQuery, List<EnumValueDescription>>
{
    private readonly IAppLogger<GetPaymentStatusListQueryHandler> _logger;

    public GetPaymentStatusListQueryHandler(
        IAppLogger<GetPaymentStatusListQueryHandler> logger)
    {
        _logger = logger;
    }

    public async Task<List<EnumValueDescription>> Handle(GetPaymentStatusListQuery request, CancellationToken cancellationToken)
    {
        return EnumExtensions.GetEnumValueDescriptionList<PaymentStatus>();
    }
}
