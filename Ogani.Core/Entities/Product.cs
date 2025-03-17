using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string IsMainPicture { get; set; } = null!;
    public List<ProductCategory> ProductCategories { get; set; } = [];
    public List<ProductImage>? ProductImages { get; set; } = [];
}

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}
public class ProductCategory : BaseEntity
{
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}

public  class ProductImage : BaseEntity
{
    public  string ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}