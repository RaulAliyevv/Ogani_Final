using AutoMapper;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;

namespace Ogani.Business.Services.Implementations;

public class CategoryService : CrudService<Category, CategoryCreateDto,CategoryUpdateDto, CategoryDto>, ICategoryService
{
    public CategoryService(ICategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}