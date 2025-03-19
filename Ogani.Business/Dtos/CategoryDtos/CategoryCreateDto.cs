using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.CategoryDtos;

public class CategoryCreateDto : IDto
{
    public required string Name { get; set; }
    public required IFormFile ImageFile { get; set; }
}
