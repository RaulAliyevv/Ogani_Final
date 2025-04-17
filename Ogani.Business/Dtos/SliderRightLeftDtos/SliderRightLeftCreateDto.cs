using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.SliderRightLeftDtos;

public class SliderRightLeftCreateDto : IDto
{
    public string RightImage { get; set; } = null!;
    public string LeftImage { get; set; } = null!;
}
