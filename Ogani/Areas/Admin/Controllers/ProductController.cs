using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Areas.Admin.Controllers;

[Area("Admin")]

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync();
        return View(products);
    }
    public async Task<IActionResult> Create()
    {
        var dto = await _productService.GetCreatedProductDto();
        return View(dto);
    }
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto dto)
    {
        var result = await _productService.ProductCreate(dto);

        if (!result.Success)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);  
            }
            var categories = await _productService.GetCreatedProductDto();
            dto.Categories = categories.Categories;
            return View(dto); 
        }

        return RedirectToAction("Index");  
    }


    public async Task<IActionResult> Update()
    {
        return View();
    }

    public async Task<IActionResult> Update(ProductUpdateDto dto)
    {
        return View(dto);
    }
}
