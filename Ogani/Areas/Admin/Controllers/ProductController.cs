using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations;

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


    public async Task<IActionResult> Update(int id)
    {
        var dto = await _productService.GetUpdateProduct(id);
        return View(dto);
    }
    [HttpPost]
    public async Task<IActionResult> Update(ProductUpdateDto dto)
    {
        return View(dto);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var product = await _productService.GetProduct(id);
        return View(product);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _productService.DeleteAsync(id);
        if (!isDeleted)
        {
            ModelState.AddModelError("", "Product dont delete");
        }

        return RedirectToAction("Index");
    }
}
