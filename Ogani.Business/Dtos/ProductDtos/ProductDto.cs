using Ogani.Business.Dtos.Base;
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

    public List<ProductImageDto>? ProductImages { get; set; }
    public List<ProductCategoryDto>? ProductCategories { get; set; }
}
