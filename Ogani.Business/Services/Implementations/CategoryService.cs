using AutoMapper;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Exceptions;
using Ogani.Business.Helpers;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Ogani.Business.Services.Implementations;

public class CategoryService : CrudService<Category, CategoryCreateDto, CategoryUpdateDto, CategoryDto>, ICategoryService
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
        if (dto == null) return false;

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new NotFoundException("Category is null");

        if (dto.ImageFile == null || dto.ImageFile.Length == 0)
            throw new NotFoundException("Image is requared");
        var result = FileHelper.ValidateImage(dto.ImageFile);

        if (!result.IsSuccess)
        {
            throw new NotFoundException($" File Is not image or file size  200 mb");
          
        }
        var img = await _cloudinaryManager.FileCreateAsync(dto.ImageFile);
        if (img == null)
            throw new Exception("image is not upload");


        var model = new Category
        {
            Name = dto.Name,
            ImageUrl = img
        };

        await _categoryRepository.CreateAsync(model);
        return true;
    }

    public async Task<bool> UpdateAsync(CategoryUpdateDto dto)
    {
        if (dto == null) return false;

        var category = await _categoryRepository.GetAsync(dto.Id);
        if (category == null)
            throw new NotFoundException("Not Found Category Name");

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new NotFoundException("Name is null");

        if (dto.ImageFile != null && dto.ImageFile.Length > 0)
        {
            var img = await _cloudinaryManager.FileCreateAsync(dto.ImageFile);
            if (img == null)
                throw new NotFoundException("Not Found Image");
            var result = FileHelper.ValidateImage(dto.ImageFile);

            if (!result.IsSuccess)
            {
                throw new NotFoundException($" File Is not image or file size  200 mb");

            }
            category.ImageUrl = img;
        }

        category.Name = dto.Name;
        _categoryRepository.Update(category);
        await _categoryRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _categoryRepository.GetAsync(id);
        if (category == null)
            throw new NotFoundException("Not Found Category");

        await _categoryRepository.Delete(category);
        return true;
    }

    public async Task<CategoryUpdateDto> GetCategoryUpdate(int id)
    {
        var category = await _categoryRepository.GetAsync(id);
        if (category is null)
        {
            throw new NotFoundException("category is null ");
        }

        var model = new CategoryUpdateDto
        {
            Name = category.Name,
            ImageUrl = category.ImageUrl
        };

        return model;
    }
}
