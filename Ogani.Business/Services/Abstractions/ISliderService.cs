using Ogani.Business.Dtos.SliderDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface ISliderService : ICrudService<Slider, CreateSliderDto, UpdateSliderDto, SliderDto>
{
    Task<UpdateSliderDto> GetUpdateSliderDto(int id);
    Task<bool> UpdateSlider(UpdateSliderDto updateSliderDto);
}
