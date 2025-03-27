using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;
namespace Ogani.Business.Services.Implementations;

public class ProductService : CrudService<Product, ProductCreateDto, ProductUpdateDto, ProductDto>, IProductService
{
    private readonly ICategoryService _categoryService;
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly IProductRepository _productRepository;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository repository, IMapper mapper, ICategoryService categoryService, ICloudinaryManager cloudinaryManager, IProductImageRepository productImageRepository) : base(repository, mapper)
    {
        _categoryService = categoryService;
        _cloudinaryManager = cloudinaryManager;
        _productRepository = repository;
        _productImageRepository = productImageRepository;
        _mapper = mapper;
    }
    public async Task<ProductCreateDto> GetCreatedProductDto()
    {
        var categories = await _categoryService.GetAllAsync();

        var model = new ProductCreateDto
        {
            Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList()
        };

        return model;
    }



    public async Task<(bool Success, List<string> Errors)> ProductCreate(ProductCreateDto dto)
    {
        var errors = new List<string>();

        if (dto == null)
        {
            errors.Add("Product data is null.");
            return (false, errors);
        }

        if (dto.ProductImages.Count == 0)
        {
            errors.Add("Product images are required.");
            return (false, errors);
        }

        if (string.IsNullOrEmpty(dto.Name))
        {
            errors.Add("Product name is required.");
        }

        if (string.IsNullOrEmpty(dto.Description))
        {
            errors.Add("Product description is required.");
        }

        if (dto.Price < 0)
        {
            errors.Add($"Price: {dto.Price} is not valid");
        }
        if (dto.CategoryId <= 0)
        {
            errors.Add("Category must be a valid ID.");
        }

        if (dto.MainImageUrl == null)
        {
            errors.Add("main image is required");
        }


        if (errors.Any()) return (false, errors);

        var imageMain = await _cloudinaryManager.FileCreateAsync(dto.MainImageUrl);

        var model = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            IsMainPicture = imageMain,
            CategoryId = dto.CategoryId
        };

        if (dto.ProductImages is null)
        {
            errors.Add(" Images are required");
        }
        await _productRepository.CreateAsync(model);

        foreach (var image in dto.ProductImages)
        {
            var uploadedImageUrl = await _cloudinaryManager.FileCreateAsync(image);
            var imageRecord = new ProductImage { ProductId = model.Id, ImageUrl = uploadedImageUrl };
            await _productImageRepository.CreateAsync(imageRecord);
        }

        return (true, new List<string>());

    }

        public async Task<ProductUpdateDto> GetProductUpdateDto(int productId)
        {
            var product = await _productRepository.GetAsync(productId);
            if (product == null) return null;

            var categories = await _categoryService.GetAllAsync();

            var productUpdateDto = new ProductUpdateDto
            {
                //    Categories = categories.Select(c => new SelectListItem
                //    {
                //        Value = c.Id.ToString(),
                //        Text = c.Name
                //    }).ToList()
            };

            return productUpdateDto;
        }


        public async Task<bool> UpdateProduct(ProductUpdateDto dto)
        {
            if (dto == null) return false;

            var product = await _productRepository.GetAsync(dto.Id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;

            if (dto.MainImageUrl != null)
            {
                var imageMain = await _cloudinaryManager.FileCreateAsync(dto.MainImageUrl);
                product.IsMainPicture = imageMain;
            }

            _productRepository.Update(product);

            foreach (var image in dto.ProductImages)
            {
                var uploadedImageUrl = await _cloudinaryManager.FileCreateAsync(image);
                var imageRecord = new ProductImage { ProductId = product.Id, ImageUrl = uploadedImageUrl };
                await _productImageRepository.CreateAsync(imageRecord);
            }

            return true;
        }

    
}



