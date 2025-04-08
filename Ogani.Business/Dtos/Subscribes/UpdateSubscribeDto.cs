using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.Subscribes
{
    public class UpdateSubscribeDto : IDto
    {
        public string Email { get; set; } = null!;
        public DateTime SubscribedDate { get; set; }
    }
}
