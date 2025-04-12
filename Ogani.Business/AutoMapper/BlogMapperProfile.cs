using AutoMapper;
using Ogani.Business.Dtos.BlogDtos;
using Ogani.Core.Entities;

namespace Ogani.Business.AutoMapper;

public class BlogMapperProfile : Profile
{
    public BlogMapperProfile()
    {
        CreateMap<Blog, BlogCreateDto>().ReverseMap();
        CreateMap<Blog, BlogDto>().ReverseMap();
        CreateMap<Blog, BlogUpdateDto>().ReverseMap();
    }
}
