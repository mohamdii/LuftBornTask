using AutoMapper;
using LuftBornTask.Application.DTOs;
using LuftBornTask.Domain.Entities;

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
