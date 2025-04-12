using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.SettingDtos;

public class SettingUpdateDto : IDto
{
    public int Id { get; set; } 
    public string? Key { get; set; } 
    public string? Value { get; set; }
    public IFormFile? UploadedImage { get; set; }
}

