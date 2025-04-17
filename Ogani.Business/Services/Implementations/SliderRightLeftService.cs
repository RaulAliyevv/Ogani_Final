using AutoMapper;
using Ogani.Business.Dtos.SliderRightLeftDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;

namespace Ogani.Business.Services.Implementations;

public class SliderRightLeftService : CrudService<SliderRightLeft, SliderRightLeftCreateDto, SliderRightLeftUpdateDto, SliderRightLeftDto>, ISliderRightLeftService
{
    public SliderRightLeftService(ISliderRightLeftRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
