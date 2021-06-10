using AutoMapper;
using Supermarket.API.DataTransferObjects;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Queries;
using Supermarket.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Mapping
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

            CreateMap<QueryResult<Product>, QueryResultDto<ProductDto>>();
        }
    }
}
