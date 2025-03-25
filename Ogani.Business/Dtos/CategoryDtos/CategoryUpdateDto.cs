using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.CategoryDtos;

public class CategoryUpdateDto : IDto
{
    public int Id { get; set; }
    public  string? Name { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ImageUrl { get; set; }
}
