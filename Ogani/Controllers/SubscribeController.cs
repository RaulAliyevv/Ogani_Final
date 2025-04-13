using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.Subscribes;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Controllers;

public class SubscribeController : Controller
{
    private readonly ISubscribeService _subscribeService;

    public SubscribeController(ISubscribeService subscribeService)
    {
        _subscribeService = subscribeService;
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeCreateDto dto)
    {
        if (!ModelState.IsValid) return RedirectToAction("Index", "Home");

        await _subscribeService.CreateAsync(dto);
        return RedirectToAction("Index", "Home");
    }
}
