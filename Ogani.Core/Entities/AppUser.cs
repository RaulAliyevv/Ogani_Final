
using Microsoft.AspNetCore.Identity;

namespace Ogani.Core.Entities;

public class AppUser : IdentityUser
{
    public string NickName { get; set; } = null!;
    public bool IsDisabled { get; set; } = false;
}
