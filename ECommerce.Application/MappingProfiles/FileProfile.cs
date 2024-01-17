using AutoMapper;
using ECommerce.Application.Features.Products.Commands.Update;
using ECommerce.Application.Features.Products.Commands.Create;
using ECommerce.Application.Features.Products.Queries.Get;
using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Domain;
using ECommerce.Application.Models.Simple.Product;
using ECommerce.Application.Models.Simple.File;

namespace ECommerce.Application.MappingProfiles
{
    public class FileProfile : Profile
    {
        public FileProfile() 
        {
            CreateMap<Domain.File, FileUrlDto>()
                .ForMember(d => d.Url, o => o.MapFrom(s => s.Path.Substring(3)));
        }
    }
}
