namespace Ogani.Core.Entities.Base;

public class BasketItem : BaseEntity
{
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public string AppUserId { get; set; } = null!;
    public int Count { get; set; }
}

public class WishlistItem : BaseEntity
{
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public string AppUserId { get; set; } = null!;
}