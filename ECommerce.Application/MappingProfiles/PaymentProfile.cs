﻿using AutoMapper;
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
            //CreateMap<ProductDto, Product>().ReverseMap();
            //CreateMap<Product, SimpleProductDto>();
            //CreateMap<Product, ProductDetailsDto>();
            CreateMap<CreateCommand, Payment>()
                .ForMember(d => d.PaymentStatus, o => o.MapFrom(s => PaymentStatus.Pending));
            CreateMap<UpdateCommand, Payment>();
            CreateMap<ChangeStatusCommand, Payment>();
        }
    }
}
