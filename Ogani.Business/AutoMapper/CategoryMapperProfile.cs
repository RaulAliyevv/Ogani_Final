using AutoMapper;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Core.Entities;

namespace Ogani.Business.AutoMapper;

public class CategoryMapperProfile : Profile
{
    public CategoryMapperProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
    }
}
