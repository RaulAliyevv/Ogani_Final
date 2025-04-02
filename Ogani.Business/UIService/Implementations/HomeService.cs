using Microsoft.EntityFrameworkCore;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Dtos.HomeDtos;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Dtos.ProductImageDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.UIService.Abstracts;

namespace Ogani.Business.UIService.Implementations;

internal class HomeService : IHomeService
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;


    public HomeService(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<HomeDto> GetHomeViewModelAsync()
    {
        var categories = await _categoryService.GetAllAsync();
        var products = await _productService.GetAllAsync(include: x => x
            .Include(y => y.ProductImages!)
            .Include(y => y.Category!)

        );

        var productDtos = products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            IsMainPicture = product.ProductImages?.FirstOrDefault()?.ImageUrl,
            Categories = product.Categories?.Select(pc => new CategoryDto
            {
                Id = pc.Id,
                Name = pc.Name
            }).ToList() ?? new List<CategoryDto>(),
            ProductImages = product.ProductImages?.Select(img => new ProductImageDto
            {
                Id = img.Id,
                ImageUrl = img.ImageUrl
            }).ToList()
        }).ToList();

        return new HomeDto
        {
            Categories = categories,
            Products = productDtos
        };
    }

}
