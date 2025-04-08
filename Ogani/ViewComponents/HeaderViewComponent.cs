using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Ogani.Business.Dtos.HomeDtos;
using Ogani.Business.Services.Abstractions;

namespace Ogani.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
	private readonly ICategoryService _categoryService;

	public HeaderViewComponent(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}
	public async Task<ViewViewComponentResult> InvokeAsync()
	{

		var categories = await _categoryService.GetAllAsync();

		HeaderDto headerDto = new HeaderDto { Categories = categories};

		return View(headerDto);
	}
}
