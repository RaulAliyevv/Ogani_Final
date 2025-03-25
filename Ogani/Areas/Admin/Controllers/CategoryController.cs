using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            if (!ModelState.IsValid) 
            {
                return View(dto);
            }
            var isCreated = await _categoryService.CreateAsync(dto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _categoryService.DeleteAsync(id);
            if (!isDeleted)
            {
                ModelState.AddModelError("", "Category dont delete");
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetCategoryUpdate(id);
            return View(category);
        }

        [HttpPost]

        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _categoryService.UpdateAsync(dto);

            return RedirectToAction("Index");
        }

    }
}
