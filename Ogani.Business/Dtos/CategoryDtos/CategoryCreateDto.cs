using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.CategoryDtos;

public class CategoryCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public IFormFile ImageFile { get; set; } = null!;
}
