using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
        public bool IsAnswer { get; set; } 
    }
}
