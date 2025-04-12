using Ogani.Business.Dtos.Subscribes;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface ISubscribeService : ICrudService<Subscribe, SubscribeCreateDto, UpdateSubscribeDto, SubscribeDto>
{

}
