using ECommerce.Domain.Enumerations.Payments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Payments.Commands.ChangeStatus
{
    public class ChangeStatusCommand : IRequest<long>
    {
        public long PaymentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
