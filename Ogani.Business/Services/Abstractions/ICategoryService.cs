using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface ICategoryService : ICrudService<Category, CategoryCreateDto, CategoryUpdateDto, CategoryDto>
{
}

