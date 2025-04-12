using Ogani.Business.Dtos.HomeDtos;

namespace Ogani.Business.UIService.Abstractions
{
    public interface IShopService
    {
        Task<ShopDto> GetShop();
        Task<ShopDto> GetShop(string? search, string? sort, int? categoryId = null);
    }
}
