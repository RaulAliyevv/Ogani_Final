using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Dtos.ProductDtos;

namespace Ogani.Business.Dtos.HomeDtos
{
    public class HomeDto 
    {
        public List<ProductDto> Products { get; set; } = [];
        public List<CategoryDto> Categories { get; set; } = [];
    }
}
