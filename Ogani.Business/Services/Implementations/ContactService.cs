using AutoMapper;
using Ogani.Business.Dtos.ContactDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;

namespace Ogani.Business.Services.Implementations;

public class ContactService : CrudService<Contact, ContactCreateDto, ContactUpdateDto, ContactDto>, IContactService
{
    public ContactService(IContactRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
