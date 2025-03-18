using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities;

public class ProductCategory : BaseEntity
{
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
