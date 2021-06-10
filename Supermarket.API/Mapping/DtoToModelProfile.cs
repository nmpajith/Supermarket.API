using AutoMapper;
using Supermarket.API.DataTransferObjects;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<CreateCategoryDto, Category>();

            CreateMap<CreateProductDto, Product>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => (EUnitOfMeasurement)src.UnitOfMeasurement));

            CreateMap<ProductsQueryDto, ProductsQuery>();
        }
    }
}