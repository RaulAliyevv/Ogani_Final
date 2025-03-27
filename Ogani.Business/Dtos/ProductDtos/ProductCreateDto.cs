using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;

using Microsoft.AspNetCore.Mvc.Rendering;
using Ogani.Business.Dtos.CategoryDtos;


namespace Ogani.Business.Dtos.ProductDtos;

public class ProductCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public IFormFile MainImageUrl { get; set; } = null!;
    public List<IFormFile> ProductImages { get; set; } = new List<IFormFile>();
    public int CategoryId { get; set; }
    public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>(); 

}
