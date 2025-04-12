using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.BlogDtos;

public class BlogDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string Text { get; set; } = null!;
}
