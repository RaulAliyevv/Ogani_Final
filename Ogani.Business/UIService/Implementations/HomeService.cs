using Microsoft.EntityFrameworkCore;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Dtos.HomeDtos;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Dtos.ProductImageDtos;
using Ogani.Business.Dtos.Subscribes;
using Ogani.Business.Exceptions;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.UIService.Abstracts;
using Ogani.Core.Entities;
using Ogani.DataAccess.Context;
using System.Data;

namespace Ogani.Business.UIService.Implementations;

internal class HomeService : IHomeService
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly ISliderService _sliderService;
    private readonly ISubscribeService _subscribeService;
   private readonly IBlogService _blogService;


    public HomeService(IProductService productService, ICategoryService categoryService, ISliderService sliderService, ISubscribeService subscribeService, IBlogService blogService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _sliderService = sliderService;
        _subscribeService = subscribeService;
        _blogService = blogService;
    }

    public async Task<HomeDto> GetHomeViewModelAsync()
    {
        var slider = await _sliderService.GetAllAsync();
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
            IsMainPicture = product.IsMainPicture,
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


        var blogs = await _blogService.GetAllAsync();

        var latestBlogs = blogs
            .OrderByDescending(b => b.CreatedTime)
            .Take(6)
            .ToList();


        return new HomeDto
        {
            Categories = categories,
            Products = productDtos,
            SliderDto =slider,
            BlogDtos = latestBlogs
        };
    }



    public async Task<DetailDto> GetDetail(int id)
    {
        var slider = await _sliderService.GetAllAsync();

        var product = await _productService.GetAsync(x=>x.Id==id ,include : x=>x.Include(x=>x.Category) .Include(c=>c.ProductImages));

        if( product is null) throw new NotFoundException();



        var relatedProducts = await _productService.GetAllAsync(x =>
          x.CategoryId == product.CategoryId && x.Id != id);


      


        var model = new DetailDto
        {
            Id=id,
            Product = product,
            SliderDto=slider,
            RelatedProducts = relatedProducts
        };

        return model;
    }

    public async Task<bool> CreateSubcribeAsync(SubscribeCreateDto dto)
    {
        if(dto is null) return false;

        var model = await _subscribeService.CreateAsync(dto);

        return true;
    }


}
