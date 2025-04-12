using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Ogani.Business.Dtos.HomeDtos;
using Ogani.Business.Services.Abstractions;

namespace Ogani.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
	private readonly ICategoryService _categoryService;
	private readonly IBasketService _basketService;
	private readonly IWishlistService _wishlistService;

    public HeaderViewComponent(ICategoryService categoryService, IBasketService basketService, IWishlistService wishlistService)
    {
        _categoryService = categoryService;
        _basketService = basketService;
        _wishlistService = wishlistService;
    }
    public async Task<ViewViewComponentResult> InvokeAsync()
	{
		var count = await _basketService.GetBasketCountAsync();
		var total = await _basketService.GetBasketTotalAsync();
		var wishlistCount = await _wishlistService.WishlistCount();


		var categories = await _categoryService.GetAllAsync();

		HeaderDto headerDto = new HeaderDto { Categories = categories,BasketCount=count,BasketTotal = total ,WishListCount =wishlistCount};

		return View(headerDto);
	}
}
