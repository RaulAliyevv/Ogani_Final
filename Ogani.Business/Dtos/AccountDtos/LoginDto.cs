using System.ComponentModel.DataAnnotations;

namespace Ogani.Business.Dtos.AccountDtos;

public class LoginDto
{
    public string Email { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
