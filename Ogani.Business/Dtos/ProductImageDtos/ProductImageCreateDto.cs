using Microsoft.AspNetCore.Http;

namespace Ogani.Business.Dtos.ProductImageDtos;

public class ProductImageCreateDto
{
    public IFormFile ImageUrl { get; set; } = null!;
}
