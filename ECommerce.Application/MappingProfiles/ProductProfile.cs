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
                .ReverseMap()
                .ForMember(d => d.Thumbnail, o => o.MapFrom<FileUrlResolver, Product>(s => s));

            CreateMap<Product, SimpleProductDto>()
                .ForMember(d => d.Thumbnail, o => o.MapFrom<FileUrlResolver, Product>(s => s));

            CreateMap<Product, ProductDetailsDto>()
                .ForMember(d => d.Thumbnail, o => o.MapFrom<FileUrlResolver, Product>(s => s))
                .ForMember(d => d.ImageUrls, o => o.Ignore());

            CreateMap<CreateCommand, Product>()
                .ForMember(d => d.Thumbnail, o => o.Ignore())
                .ForMember(s => s.Files, o => o.Ignore());

            CreateMap<UpdateCommand, Product>()
                .ForMember(d => d.Thumbnail, o => o.Ignore())
                .ForMember(s => s.Files, o => o.Ignore());
        }
    }
}
