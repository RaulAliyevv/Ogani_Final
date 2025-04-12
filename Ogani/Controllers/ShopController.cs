using Microsoft.AspNetCore.Mvc;
using Ogani.Business.UIService.Abstractions;

namespace Ogani.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        public IActionResult Shop()
        {
            return View();
        }
        public async Task<IActionResult> Index(string? search, string? sort , int? categoryId)
        {
            var shop = await _shopService.GetShop(search, sort ,categoryId);
            return View(shop);
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            return RedirectToAction("Index", new { search });
        }
            
    }
}
