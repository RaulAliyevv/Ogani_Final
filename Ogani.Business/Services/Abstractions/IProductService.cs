using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface IProductService : ICrudService<Product ,ProductCreateDto, ProductUpdateDto,ProductDto>
{ 
}

