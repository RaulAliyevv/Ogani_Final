using AutoMapper;
using Ogani.Business.Dtos.ProductImageDtos;
using Ogani.Core.Entities;

namespace Ogani.Business.AutoMapper;

public class ProductImageMapperProfile : Profile
{
    public ProductImageMapperProfile()
    {
        CreateMap<ProductImage, ProductImageDto>().ReverseMap();
        CreateMap<ProductImage, ProductImageCreateDto>().ReverseMap();
        CreateMap<ProductImage, ProductImageUpdateDto>().ReverseMap();
    }
}
