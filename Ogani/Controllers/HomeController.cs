using Microsoft.AspNetCore.Mvc;
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

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
