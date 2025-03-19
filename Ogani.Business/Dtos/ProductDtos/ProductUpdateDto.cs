using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;
using System.Web.Mvc;

namespace Ogani.Business.Dtos.ProductDtos;

public class ProductUpdateDto : IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string? MainImageUrl { get; set; }

    public List<IFormFile> ProductImages { get; set; } = [];
    public List<SelectListItem> ProductCategories { get; set; } = [];
}
