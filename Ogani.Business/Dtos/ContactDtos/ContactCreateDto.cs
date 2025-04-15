using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos.ContactDtos
{
    public class ContactCreateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Answer { get; set; } 
        public bool IsAnswer { get; set; }
    }
}
