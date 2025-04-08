using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IActionResult> AddToBasket(int id)
    {
        var basket = await _basketService.AddToBasketAsync(id);
        return RedirectToAction("index");
    }

    public async Task<IActionResult> GetBasket()
    {
        var basketItems = await _basketService.GetBasketAsync();

        return PartialView("_BasketPartial", basketItems);
    }
}
