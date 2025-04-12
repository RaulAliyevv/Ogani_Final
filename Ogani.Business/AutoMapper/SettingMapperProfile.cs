using AutoMapper;
using Ogani.Business.Dtos.SettingDtos;
using Ogani.Core.Entities;

namespace Ogani.Business.AutoMapper;

public class SettingMapperProfile : Profile
{
    public SettingMapperProfile()
    {
        CreateMap<Setting, SettingCreateDto>().ReverseMap();
        CreateMap<Setting, SettingDto>().ReverseMap();
        CreateMap<Setting, SettingUpdateDto>().ReverseMap();
    }
}