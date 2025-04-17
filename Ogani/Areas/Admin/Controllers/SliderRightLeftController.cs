using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SliderRightLeftController : Controller
    {
        private readonly ISliderRightLeftService _sliderRightLeftService;

        public SliderRightLeftController(ISliderRightLeftService sliderRightLeftService)
        {
            _sliderRightLeftService = sliderRightLeftService;
        }

        public async Task<IActionResult> Index()
        {
            var sliderRightLeft = await _sliderRightLeftService.GetAllAsync();
            return View(sliderRightLeft);
        }
    }
}
