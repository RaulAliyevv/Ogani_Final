using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Dtos.SliderDtos;

namespace Ogani.Business.Dtos.HomeDtos
{
    public class DetailDto
    {
        public int Id { get; set; } 
        public ProductDto Product { get; set; } = null!;
        public List<ProductDto> RelatedProducts { get; set; } = [];
        public List<SliderDto> SliderDto { get; set; } = [];

    }
}
