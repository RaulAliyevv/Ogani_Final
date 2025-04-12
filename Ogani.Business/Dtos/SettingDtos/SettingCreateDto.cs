using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.SettingDtos;

public class SettingCreateDto : IDto
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}

