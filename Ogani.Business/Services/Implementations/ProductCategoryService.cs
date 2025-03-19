using AutoMapper;
using Ogani.Business.Dtos.ProductCategoryDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;

namespace Ogani.Business.Services.Implementations;

public class ProductCategoryService : CrudService<ProductCategory, ProductCategoryCreateDto, ProductCategoryUpdateDto, ProductCategoryDto>, IProductCategoryService
{
    public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
