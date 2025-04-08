using AutoMapper;
using Ogani.Business.Dtos.Subscribes;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Implementations;

public class SubscribeService : CrudService<Subscribe, SubscribeCreateDto, UpdateSubscribeDto, SubscribeDto>, ISubscribeService
{
    public SubscribeService(ISubscribeRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}