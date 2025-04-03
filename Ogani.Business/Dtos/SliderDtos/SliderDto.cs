using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.SliderDtos;

public class SliderDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImgUrl { get; set; } = null!;
    public string GreenWrite { get; set; } = null!;
    public string BoldWrite { get; set; } = null!;
    public string LightWrite { get; set; } = null!;
    public string ButtonWrite { get; set; } = null!;
}