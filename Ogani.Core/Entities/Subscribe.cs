using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities;

public class Subscribe : BaseEntity
{
    public string Email { get; set; } = null!;
    public DateTime SubscribedDate { get; set; }

}
