using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var blog = await _blogService.GetAsync(id);
            return View(blog);
        }
    }
}
