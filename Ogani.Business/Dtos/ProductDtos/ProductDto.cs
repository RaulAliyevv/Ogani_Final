using Ogani.Business.Dtos.Base;
using Ogani.Business.Dtos.CategoryDtos;
using Ogani.Business.Dtos.ProductCategoryDtos;
using Ogani.Business.Dtos.ProductImageDtos;

namespace Ogani.Business.Dtos.ProductDtos;

public class ProductDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string? IsMainPicture { get; set; }
    public string? CategoryName { get; set; }
    public int CategoryId { get; set; }
    public List<CategoryDto> Categories { get; set; } = new();

    public List<ProductImageDto>? ProductImages { get; set; }
}
