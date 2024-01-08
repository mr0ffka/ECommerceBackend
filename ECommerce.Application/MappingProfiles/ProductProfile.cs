﻿using AutoMapper;
using ECommerce.Application.Features.Products.Commands.Update;
using ECommerce.Application.Features.Products.Commands.Create;
using ECommerce.Application.Features.Products.Queries.Get;
using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Domain;
using ECommerce.Application.Models.Simple.Product;

namespace ECommerce.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<Product, SimpleProductDto>();
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<CreateCommand, Product>();
            CreateMap<UpdateCommand, Product>();
        }
    }
}
