using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace Ogani.ViewComponents;

public class FooterViewComponent : ViewComponent
{
	public async Task<ViewViewComponentResult> InvokeAsync()
	{
		return View();
	}
}
