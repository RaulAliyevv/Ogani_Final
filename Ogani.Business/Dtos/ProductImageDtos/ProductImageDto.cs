using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.ProductImageDtos;

public class ProductImageDto : IDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
}
