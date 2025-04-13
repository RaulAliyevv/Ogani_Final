using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ogani.Business.Dtos.SettingDtos;
using Ogani.Business.Dtos.SliderDtos;
using Ogani.Business.Exceptions;
using Ogani.Business.Helpers;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Implementations;

public class SettingService : CrudService<Setting, SettingCreateDto, SettingUpdateDto, SettingDto>, ISettingService
{
    private readonly ISettingRepository _settingRepository;
    private readonly ICloudinaryManager _cloudinaryManager;
    public SettingService(ISettingRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _settingRepository = repository;
        _cloudinaryManager = cloudinaryManager;
    }

    public string GetSetting(string key)
    {
        return _settingRepository.GetSettingByKey(key);
    }

    public async Task<SettingUpdateDto> SettingUpdateDto(int id)
    {
        
        var setting = await _settingRepository.GetAsync(x=>x.Id == id);
       

        var model = new SettingUpdateDto
        {
            Key = setting.Key,
            Value = setting.Value
        };

        return model;
    }

    public async Task UpdateSettingAsync(SettingUpdateDto settingUpdateDTO)
    {
        var setting = await _settingRepository.GetAsync(s => s.Id == settingUpdateDTO.Id);

        if (setting == null)
        {
            throw new NotFoundException("Setting not found");
        }

        if (settingUpdateDTO.UploadedImage != null)
        {
            var validationResult = FileHelper.ValidateImage(settingUpdateDTO.UploadedImage);
            if (!validationResult.IsSuccess)
                throw new NotFoundException("File is not image və size is not 200MB.");


            var filePath = await _cloudinaryManager.FileCreateAsync(settingUpdateDTO.UploadedImage);

            setting.Value = filePath;
        }
        else
        {
            if(settingUpdateDTO.Value == null)
            {
                throw new NotFoundException("Setting not found");
            }
            setting.Value = settingUpdateDTO.Value;

        }
         _settingRepository.Update(setting);

        await _settingRepository.SaveChangesAsync();
    }
}