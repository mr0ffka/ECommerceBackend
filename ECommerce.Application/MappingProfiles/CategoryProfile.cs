using AutoMapper;
using ECommerce.Application.Features.Categories.Commands.Create;
using ECommerce.Application.Features.Categories.Commands.Update;
using ECommerce.Application.Features.Categories.Queries.GetById;
using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Domain;

namespace ECommerce.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryListDto, Category>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCommand, Category>();
            CreateMap<UpdateCommand, Category>();
        }
    }
}
