using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.SliderDtos;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.GetAllAsync();
            return View(sliders);
        }   

        public async Task<IActionResult> Update(int id)
        {
            var model = await _sliderService.GetUpdateSliderDto(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSliderDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _sliderService.UpdateSlider(dto);

            return RedirectToAction("Index");
        }
    }
}
