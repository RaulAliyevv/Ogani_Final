using AutoMapper;
using Ogani.Business.Dtos.SliderDtos;
using Ogani.Core.Entities;

namespace Ogani.Business.AutoMapper;

public class SliderMapperProfile : Profile
{
    public SliderMapperProfile()
    {
        CreateMap<Slider, SliderDto>().ReverseMap();
        CreateMap<Slider, CreateSliderDto>().ReverseMap();
        CreateMap<Slider, UpdateSliderDto>().ReverseMap();
    }
}