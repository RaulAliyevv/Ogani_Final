using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ogani.Business.Dtos.Base;
using Ogani.Business.Dtos.ProductImageDtos;

namespace Ogani.Business.Dtos.ProductDtos;

public class ProductUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string? ImageMain { get; set; }
    public IFormFile? MainImageUrl { get; set; }

    public List<ProductImageDto> imgUrl { get; set; } = [];
    public List<IFormFile> ProductImages { get; set; } = [];

    public int CategoryId { get; set; } 

    public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
}
