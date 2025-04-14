using Ogani.Business.Dtos.ContactDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface IContactService : ICrudService<Contact, ContactCreateDto, ContactUpdateDto, ContactDto>
{
    Task<ContactCreateDto> ContactCreateDtoAsync(int id);
    Task<bool> SendEmailContact(ContactCreateDto dto);
}