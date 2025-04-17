using AutoMapper;
using Ogani.Business.Dtos.BlogDtos;
using Ogani.Business.Dtos.SliderRightLeftDtos;
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

public class SliderRightLeftMapperProfile : Profile
{
    public SliderRightLeftMapperProfile()
    {
        CreateMap<SliderRightLeft, SliderRightLeftDto>().ReverseMap();
        CreateMap<SliderRightLeft, SliderRightLeftCreateDto>().ReverseMap();
        CreateMap<SliderRightLeft, SliderRightLeftUpdateDto>().ReverseMap();
    }
}
