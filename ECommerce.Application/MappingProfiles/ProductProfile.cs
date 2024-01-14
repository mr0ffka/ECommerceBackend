using AutoMapper;
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
            CreateMap<ProductDto, Product>()
                .ForMember(d => d.Files, o => o.Ignore())
                .ReverseMap();

            CreateMap<Product, SimpleProductDto>();

            CreateMap<Product, ProductDetailsDto>()
                .ForMember(d => d.ImageUrls, o => o.Ignore());

            CreateMap<CreateCommand, Product>()
                .ForMember(s => s.Files, o => o.Ignore());

            CreateMap<UpdateCommand, Product>()
                .ForMember(s => s.Files, o => o.Ignore());
        }
    }
}
