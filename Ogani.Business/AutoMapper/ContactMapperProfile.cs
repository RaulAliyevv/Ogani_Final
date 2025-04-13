using AutoMapper;
using Ogani.Business.Dtos.ContactDtos;
using Ogani.Core.Entities;

namespace Ogani.Business.AutoMapper;

public class ContactMapperProfile : Profile
{
    public ContactMapperProfile()
    {
        CreateMap<Contact, ContactCreateDto>().ReverseMap();
        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<Contact, ContactUpdateDto>().ReverseMap();
    }
}
