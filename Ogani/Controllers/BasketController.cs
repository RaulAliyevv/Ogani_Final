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

    [HttpPost]
    public async Task<IActionResult> AddToBasket(int id)
    {
        await _basketService.AddToBasketAsync(id);

        var count = await _basketService.GetBasketCountAsync();
        var total = await _basketService.GetBasketTotalAsync();

        return Json(new { success = true, count = count ,total= total});
    }


    public async Task<IActionResult> Index()
    {
        var basketItems = await _basketService.GetBasketAsync();

        return View(basketItems);
    }
    [HttpPost]

    public async Task<IActionResult> Deacrease(int id)
    {
        await _basketService.DecreaseFromBasketAsync(id);
        var count = await _basketService.GetBasketCountAsync();
        var total = await _basketService.GetBasketTotalAsync();

        return Json(new { success = true, count = count, total = total });
    }

    public async Task<IActionResult> GetCountAndTotal()
    {
        var count = await _basketService.GetBasketCountAsync();
        var total = await _basketService.GetBasketTotalAsync();

        return Json(new {  count = count, total = total });
    }



}
