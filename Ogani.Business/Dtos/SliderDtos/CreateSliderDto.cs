using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.SliderDtos;

public class CreateSliderDto : IDto
{
    public string Name { get; set; } = null!;
    public IFormFile ImgUrl { get; set; } = null!;
    public string GreenWrite { get; set; } = null!;
    public string BoldWrite { get; set; } = null!;
    public string LightWrite { get; set; } = null!;
    public string ButtonWrite { get; set; } = null!;
}
