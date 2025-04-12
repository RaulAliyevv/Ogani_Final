using Ogani.Business.Dtos;
using Ogani.Business.Dtos.BasketDtos;

namespace Ogani.Business.Services.Abstractions;

public interface IBasketService
{
    Task<bool> AddToBasketAsync(int id, int count = 1);
    Task<CardDto> GetBasketAsync();
    Task<int> GetBasketCountAsync();
    Task<decimal> GetBasketTotalAsync();
    Task<bool> DecreaseFromBasketAsync(int productId);

}
