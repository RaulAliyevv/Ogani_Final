using Ogani.Business.Dtos.WishlistDtos;

namespace Ogani.Business.Services.Abstractions;

public interface IWishlistService
{
    Task<bool> AddToWishListAsync(int id);
    Task<int> WishlistCount();
    Task<WishListCardDto> WishListCardDto();

}
