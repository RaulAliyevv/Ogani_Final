using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.BlogDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations;

namespace Ogani.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogController : Controller
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<IActionResult> Index()
    {
        var blog = await _blogService.GetAllAsync();
        return View(blog);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BlogCreateDto dto)
    {
       var result = await _blogService.CreateBlog(dto);
        if (!result.Success)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
           
            return View(dto);
        }
        return RedirectToAction("index");
    }
}
