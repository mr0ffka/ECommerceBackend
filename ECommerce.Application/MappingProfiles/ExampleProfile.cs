using AutoMapper;
using ECommerce.Application.Features.Example.Commands.CreateExample;
using ECommerce.Application.Features.Example.Commands.UpdateExample;
using ECommerce.Application.Features.Example.Queries.GetAllExample;
using ECommerce.Application.Features.Example.Queries.GetExampleDetails;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.MappingProfiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile() 
        {
            CreateMap<ExampleDto, Example>().ReverseMap();
            CreateMap<Example, ExampleDetailsDto>();
            CreateMap<CreateExampleCommand, Example>();
            CreateMap<UpdateExampleCommand, Example>();
        }
    }
}
