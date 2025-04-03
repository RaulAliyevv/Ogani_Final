using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
}
