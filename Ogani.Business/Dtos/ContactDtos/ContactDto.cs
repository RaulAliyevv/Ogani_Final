using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.ContactDtos
{
    public class ContactDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAnswer { get; set; }
        public string Message { get; set; }
    }
}
