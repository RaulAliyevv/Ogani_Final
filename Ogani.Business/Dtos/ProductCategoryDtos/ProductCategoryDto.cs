using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.ProductCategoryDtos;

public class ProductCategoryDto : IDto
{
    public int CategoryId { get; set; }
    public int ProductId { get; set; }
}
