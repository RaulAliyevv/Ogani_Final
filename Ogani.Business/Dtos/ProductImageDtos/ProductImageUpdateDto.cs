using Microsoft.AspNetCore.Http;

namespace Ogani.Business.Dtos.ProductImageDtos;

public class ProductImageUpdateDto
{
    public IFormFile? ImageUrl { get; set; }
}
