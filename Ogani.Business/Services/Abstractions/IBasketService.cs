using static Ogani.Business.Services.Implementations.BasketService;

namespace Ogani.Business.Services.Abstractions;

public interface IBasketService
{
    Task<bool> AddToBasketAsync(int id, int count = 1);
    Task<List<BasketItemDto>> GetBasketAsync();
}
