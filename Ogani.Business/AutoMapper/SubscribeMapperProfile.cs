using AutoMapper;
using Ogani.Business.Dtos.Subscribes;
using Ogani.Core.Entities;

namespace Ogani.Business.AutoMapper;

public class SubscribeMapperProfile : Profile
{
    public SubscribeMapperProfile()
    {
        CreateMap<Subscribe, SubscribeDto>().ReverseMap();
        CreateMap<Contact, SubscribeDto>().ReverseMap();
        CreateMap<Contact, UpdateSubscribeDto>().ReverseMap();
    }
}
