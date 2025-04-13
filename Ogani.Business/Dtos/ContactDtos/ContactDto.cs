using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.ContactDtos
{
    public class ContactDto : IDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
