using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.ProductImageDtos;

public class ProductImageDto : IDto
{
    public string ImageUrl { get; set; } = null!;
}
