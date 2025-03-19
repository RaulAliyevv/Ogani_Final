using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.ProductImageDtos;

public class ProductImageUpdateDto : IDto
{
    public IFormFile? ImageUrl { get; set; }
}
