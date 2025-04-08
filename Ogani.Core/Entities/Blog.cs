using Ogani.Core.Entities.Base;

namespace Ogani.Core.Entities
{
	public class Blog : BaseAuditableEntity
	{
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string ImageUrl { get; set; } = null!;

	}
}
