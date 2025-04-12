using Ogani.Business.Dtos.CategoryDtos;

namespace Ogani.Business.Dtos.HomeDtos
{
    public class HeaderDto
    {
        public List<CategoryDto> Categories { get; set; } = [];
        public int BasketCount { get;set; }
        public int WishListCount { get;set; }
        public decimal BasketTotal { get;set; }
    }
}
