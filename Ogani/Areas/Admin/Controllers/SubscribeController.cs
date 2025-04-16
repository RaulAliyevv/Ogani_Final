using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Maderator")]

    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public async Task<IActionResult> Index()
        {
            var subscribe = await _subscribeService.GetAllAsync();
            return View(subscribe);
        }
    }
}
