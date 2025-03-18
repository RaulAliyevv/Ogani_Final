using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}

