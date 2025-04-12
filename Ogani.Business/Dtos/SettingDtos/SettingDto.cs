using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.SettingDtos;

public class SettingDto : IDto
{
    public int Id { get; set; } 
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}

