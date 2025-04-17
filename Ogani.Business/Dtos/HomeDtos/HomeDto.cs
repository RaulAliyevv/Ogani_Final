using Ogani.Business.Dtos.BlogDtos;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Dtos.SliderDtos;
using Ogani.Business.Dtos.SliderRightLeftDtos;

namespace Ogani.Business.Dtos.HomeDtos;

public class HomeDto 
{
    public List<ProductDto> Products { get; set; } = [];
    public List<CategoryDto> Categories { get; set; } = [];
    public List<SliderDto> SliderDto { get; set; } = [];
    public List<BlogDto> BlogDtos { get; set; } = [];
    public List<SliderRightLeftDto> sliderRightLefts { get; set; } = [];
}
