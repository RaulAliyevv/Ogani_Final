namespace Ogani.Business.Dtos.WishlistDtos;

public class WishlistDto
{
    public string? img { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public decimal TotalProductPrice { get; set; }
}