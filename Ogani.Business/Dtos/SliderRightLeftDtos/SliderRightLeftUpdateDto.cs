using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.SliderRightLeftDtos;

public class SliderRightLeftUpdateDto : IDto
{
    public string RightImage { get; set; } = null!;
    public string LeftImage { get; set; } = null!;
}