using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.CategoryDtos;

public class CategoryDto : IDto
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
}
