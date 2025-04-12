using Ogani.Business.Dtos.BasketItemDtos;
using Ogani.Core.Entities;

namespace Ogani.Business.Dtos.WishlistDtos;

public class WishListCardDto
{
    public List<WishlistItemCard> Prroduct { get; set; } = new List<WishlistItemCard>();

}
