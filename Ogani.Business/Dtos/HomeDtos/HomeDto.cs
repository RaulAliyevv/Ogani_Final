using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Dtos.SliderDtos;

namespace Ogani.Business.Dtos.HomeDtos
{
    public class HomeDto 
    {
        public List<ProductDto> Products { get; set; } = [];
        public List<CategoryDto> Categories { get; set; } = [];
        public List<SliderDto> SliderDto { get; set; } = [];
    }
}
