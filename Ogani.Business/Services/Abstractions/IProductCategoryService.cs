using Ogani.Business.Dtos.ProductCategoryDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface IProductCategoryService : ICrudService<ProductCategory, ProductCategoryCreateDto, ProductCategoryUpdateDto, ProductCategoryDto>
{
}

