using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ogani.Business.Dtos;
using Ogani.Business.Dtos.Subscribes;
using Ogani.Business.UIService.Abstracts;
using Ogani.Models;
using System.Diagnostics;

namespace Ogani.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _homeService.GetHomeViewModelAsync();
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model = await _homeService.GetDetail(id);
            return View(model);
        }

        public async Task<IActionResult> Subcribe(SubscribeCreateDto dto)
        {
            var succsuss = await _homeService.CreateSubcribeAsync(dto);
            return RedirectToAction("Index");

        }


        public IActionResult Error(string? json)
        {
            if (!string.IsNullOrEmpty(json))
            {

                string decodedJson = Uri.UnescapeDataString(json);

                var dto = JsonConvert.DeserializeObject<ErrorDto>(decodedJson);
                return View(dto);
            }

            return View(new ErrorDto
            {
                StatusCode = 404,
                Message = "Error"
            });
        }

     
    }
}
