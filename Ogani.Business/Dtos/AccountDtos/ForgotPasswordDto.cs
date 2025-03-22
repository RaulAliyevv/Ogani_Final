using System.ComponentModel.DataAnnotations;

namespace Ogani.Business.Dtos.AccountDtos;

public class ForgotPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
