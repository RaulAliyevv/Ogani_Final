using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities;

public  class ProductImage : BaseEntity
{
    public  string ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}