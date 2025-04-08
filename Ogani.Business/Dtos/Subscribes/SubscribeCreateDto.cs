using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.Subscribes
{
    public class SubscribeCreateDto : IDto
    {
        public string? Email { get; set; } 
        public DateTime SubscribedDate { get; set; }
    }
}
