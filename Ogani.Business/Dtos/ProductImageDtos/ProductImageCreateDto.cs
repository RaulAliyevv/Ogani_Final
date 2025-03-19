using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.ProductImageDtos;

public class ProductImageCreateDto : IDto
{
    public IFormFile ImageUrl { get; set; } = null!;
}
