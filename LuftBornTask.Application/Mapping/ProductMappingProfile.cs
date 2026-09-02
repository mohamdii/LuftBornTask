using AutoMapper;
using LuftBornTask.Application.DTOs;
using LuftBornTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
