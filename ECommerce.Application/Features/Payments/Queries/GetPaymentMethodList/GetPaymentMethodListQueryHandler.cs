using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Extensions;
using ECommerce.Application.Models.Common;
using ECommerce.Domain.Enumerations.Payments;
using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.GetPaymentMethodList;

public class GetPaymentMethodListQueryHandler : IRequestHandler<GetPaymentMethodListQuery, List<EnumValueDescription>>
{
    private readonly IAppLogger<GetPaymentMethodListQueryHandler> _logger;

    public GetPaymentMethodListQueryHandler(
        IAppLogger<GetPaymentMethodListQueryHandler> logger)
    {
        _logger = logger;
    }

    public async Task<List<EnumValueDescription>> Handle(GetPaymentMethodListQuery request, CancellationToken cancellationToken)
    {
        return EnumExtensions.GetEnumValueDescriptionList<PaymentMethod>();
    }
}
