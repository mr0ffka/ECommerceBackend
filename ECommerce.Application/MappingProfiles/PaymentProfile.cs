using AutoMapper;
using ECommerce.Application.Features.Payments.Commands.ChangeStatus;
using ECommerce.Application.Features.Payments.Commands.Create;
using ECommerce.Application.Features.Payments.Commands.Update;
using ECommerce.Domain;
using ECommerce.Domain.Enumerations.Payments;

namespace ECommerce.Application.MappingProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile() 
        {
            CreateMap<CreateCommand, Payment>()
                .ForMember(d => d.PaymentStatus, o => o.MapFrom(s => PaymentStatus.Pending));
            CreateMap<UpdateCommand, Payment>();
            CreateMap<ChangeStatusCommand, Payment>();
            CreateMap<Payment, PaymentHistory>()
                .ForMember(d => d.PaymentId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Payment, o => o.Ignore());
        }
    }
}
