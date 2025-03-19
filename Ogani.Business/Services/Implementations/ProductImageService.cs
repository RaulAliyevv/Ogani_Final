using AutoMapper;
using Ogani.Business.Dtos.ProductImageDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;

namespace Ogani.Business.Services.Implementations;

public class ProductImageService : CrudService<ProductImage, ProductImageCreateDto, ProductImageUpdateDto, ProductImageDto>, IProductImageService
{
    public ProductImageService(IProductImageRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
