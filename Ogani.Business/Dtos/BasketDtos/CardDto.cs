using Ogani.Core.Entities.Base;

namespace Ogani.Business.Dtos.BasketDtos
{
    public class CardDto
    {
        public List<BasketItemDto> Prroduct { get; set; }= new List<BasketItemDto>();
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }    

    }
}
