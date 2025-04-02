using AutoMapper;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Core.Entities;

namespace Ogani.Business.AutoMapper;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Product, ProductDto>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
                  .ForMember(dest => dest.Categories, opt => opt.MapFrom(src =>
                src.Category != null ? new List<CategoryDto> { new CategoryDto { Id = src.Category.Id, Name = src.Category.Name } } : new List<CategoryDto>()
            ))
                    .ReverseMap()
                    .ForMember(dest => dest.Category, opt => opt.Ignore()); 
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
    }
}
