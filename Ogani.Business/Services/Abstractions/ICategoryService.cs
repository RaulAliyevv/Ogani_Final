using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;
using System.Web.Mvc;

namespace Ogani.Business.Services.Abstractions;

public interface ICategoryService : ICrudService<Category, CategoryCreateDto, CategoryUpdateDto, CategoryDto>
{
    Task<bool> CreateAsync(CategoryCreateDto dto );
    Task<bool> UpdateAsync(CategoryUpdateDto dto);
    Task<bool> DeleteAsync(int id);
     Task<CategoryUpdateDto> GetCategoryUpdate(int id);
}

