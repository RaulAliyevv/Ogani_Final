using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.CategoryDtos;

public class CategoryUpdateDto : IDto
{
    public required string Name { get; set; }
    public IFormFile? ImageFile { get; set; }
}
