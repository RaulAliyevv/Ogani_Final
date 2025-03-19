using AutoMapper;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Core.Entities;

namespace Ogani.Business.AutoMapper;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
    }
}
