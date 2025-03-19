using Ogani.Business.Dtos.ProductImageDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface IProductImageService : ICrudService<ProductImage, ProductImageCreateDto, ProductImageUpdateDto, ProductImageDto>
{
}

