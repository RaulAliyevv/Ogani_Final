using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface IProductService : ICrudService<Product, ProductCreateDto, ProductUpdateDto, ProductDto>
{
    Task<ProductCreateDto> GetCreatedProductDto();
    Task<ProductUpdateDto> GetUpdateProduct(int id);
    Task<(bool Success, List<string> Errors)> ProductCreate(ProductCreateDto dto);
    Task<bool> DeleteAsync(int id);
    Task<ProductDto> GetProduct(int id);
}


