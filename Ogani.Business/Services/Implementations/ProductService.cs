using AutoMapper;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions;

namespace Ogani.Business.Services.Implementations;

public class ProductService : CrudService<Product, ProductCreateDto, ProductUpdateDto, ProductDto>, IProductService
{
    public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
