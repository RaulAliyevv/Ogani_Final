using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string IsMainPicture { get; set; } = null!;
    public List<ProductCategory> ProductCategories { get; set; } = [];
    public List<ProductImage>? ProductImages { get; set; } = [];
}
