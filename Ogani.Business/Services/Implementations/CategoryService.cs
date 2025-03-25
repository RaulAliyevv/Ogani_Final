using AutoMapper;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;
using System.Web.Mvc;

namespace Ogani.Business.Services.Implementations;

public class CategoryService : CrudService<Category, CategoryCreateDto,CategoryUpdateDto, CategoryDto>, ICategoryService
{

    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _cloudinaryManager = cloudinaryManager;
        _categoryRepository = repository;
    }

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        if(dto is null)
        {
            return false;
        }
    
        var img = await _cloudinaryManager.FileCreateAsync(dto.ImageFile);
        if(img is null)
        {
            return false;
        }

        var model = new Category
        {
            Name = dto.Name,
            ImageUrl = img
        };

        await _categoryRepository.CreateAsync(model);
        return true;
    }
}