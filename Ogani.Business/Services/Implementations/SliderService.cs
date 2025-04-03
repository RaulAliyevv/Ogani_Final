using AutoMapper;
using Ogani.Business.Dtos.SliderDtos;
using Ogani.Business.Exceptions;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Implementations;

public class SliderService : CrudService<Slider, CreateSliderDto, UpdateSliderDto, SliderDto>, ISliderService
{
    private readonly ISliderRepository _sliderRepository;
    private readonly ICloudinaryManager _cloudinary;


    public SliderService(ISliderRepository repository, IMapper mapper, ICloudinaryManager cloudinary) : base(repository, mapper)
    {
        _sliderRepository = repository;
        _cloudinary = cloudinary;
    }


    public async Task<UpdateSliderDto> GetUpdateSliderDto(int id )
    {
        var dto = await _sliderRepository.GetAsync(id);
        if (dto == null) throw new NotFoundException();

        var update = new UpdateSliderDto { 
            Id = id ,
            BoldWrite = dto.BoldWrite,
            ButtonWrite = dto.ButtonWrite,
            LightWrite = dto.LightWrite,
            Name = dto.Name,
            GreenWrite = dto.GreenWrite,
            ImgUrlPicture = dto.ImgUrl

        };

        return update;


    }
    public async Task<bool> UpdateSlider(UpdateSliderDto updateSliderDto)
    {
        if (updateSliderDto is null)
        {
            throw new NotFoundException();
        }

        var slider = await _sliderRepository.GetAsync(updateSliderDto.Id);

        if (slider == null) throw new NotFoundException();

        if (updateSliderDto.ImgUrl != null)
        {
            string newImageUrl = await _cloudinary.FileCreateAsync(updateSliderDto.ImgUrl);

          

            slider.ImgUrl = newImageUrl;
        }

        slider.Name = updateSliderDto.Name;
        slider.GreenWrite = updateSliderDto.GreenWrite;
        slider.BoldWrite = updateSliderDto.BoldWrite;
        slider.LightWrite = updateSliderDto.LightWrite;
        slider.ButtonWrite = updateSliderDto.ButtonWrite;

         _sliderRepository.Update(slider);
        await _sliderRepository.SaveChangesAsync();

        return true;
    }




}
