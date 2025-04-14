using AutoMapper;
using Ogani.Business.Dtos.ContactDtos;
using Ogani.Business.Exceptions;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;

namespace Ogani.Business.Services.Implementations;

public class ContactService : CrudService<Contact, ContactCreateDto, ContactUpdateDto, ContactDto>, IContactService
{

    private readonly IContactRepository _contactRepository;
    private readonly IEmailService _emailService;
    public ContactService(IContactRepository repository, IMapper mapper, IEmailService emailService) : base(repository, mapper)
    {
        _contactRepository = repository;
        _emailService = emailService;
    }


    public async Task<ContactCreateDto> ContactCreateDtoAsync(int id)
    {
        var model = await _contactRepository.GetAsync(id);

        if (model  == null)
        {
            throw new NotFoundException();
        }

        var dto = new ContactCreateDto { Name = model.Name, Email = model.Email ,Message = model.Message ,Id = model.Id};

        return dto;
    }

    public async Task<bool> SendEmailContact(ContactCreateDto dto)
    {
        if (dto == null)
        {
            throw new NotFoundException();
        }
       


         _emailService.SendEmail(dto.Email,"Dear Customer" ,dto.Answer);

        var model = await _contactRepository.GetAsync(dto.Id);
        if (model == null)
        {
            throw new NotFoundException();
        }

        model.IsAnswer = true;

        _contactRepository.Update(model);
        await _contactRepository.SaveChangesAsync();

        return true;
    }
}
