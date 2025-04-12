using Ogani.Business.Dtos.SettingDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface ISettingService : ICrudService<Setting, SettingCreateDto, SettingUpdateDto, SettingDto>
{
    string GetSetting(string key);
    Task<SettingUpdateDto> SettingUpdateDto(int id);
    Task UpdateSettingAsync(SettingUpdateDto settingUpdateDTO);
}
