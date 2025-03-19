using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.ProductCategoryDtos;

public class ProductCategoryCreateDto : IDto
{
    public int CategoryId { get; set; }
    public int ProductId { get; set; }
}
