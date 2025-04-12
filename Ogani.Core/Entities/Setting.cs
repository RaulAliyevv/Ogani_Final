using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities
{
    public class Setting : BaseEntity
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
