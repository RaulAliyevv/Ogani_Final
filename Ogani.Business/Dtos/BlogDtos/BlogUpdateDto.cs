using Microsoft.AspNetCore.Http;
using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.BlogDtos;

public class BlogUpdateDto : IDto
{
    public int Id {  get; set; }    
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile ImageUrl { get; set; } = null!;
    public string ImageUrlPath { get; set; } = null!;
    public string Text { get; set; } = null!;
}
