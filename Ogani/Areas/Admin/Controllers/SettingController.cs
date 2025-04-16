using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.SettingDtos;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Maderator")]

    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            var settings = await _settingService.GetAllAsync();
            return View(settings);
        }

        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var updateDto = await _settingService.SettingUpdateDto(id);

            return View(updateDto);

        }
        [HttpPost]
        public async Task<IActionResult> Update(SettingUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _settingService.UpdateSettingAsync(dto);

            return RedirectToAction("index");
        }
    }
}
