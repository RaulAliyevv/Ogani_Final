using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities;

public class Slider : BaseEntity
{
    public string Name { get; set; } = null!;
    public string ImgUrl { get; set; } = null!;
    public string GreenWrite { get; set; } = null!;
    public string BoldWrite { get; set; } = null!;
    public string LightWrite { get; set; } = null!;
    public string ButtonWrite { get; set; } = null!;

}
