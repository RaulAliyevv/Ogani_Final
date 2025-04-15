namespace Ogani.Business.Dtos.UserDtos;

public class UserWithRoleDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}

public class ChangeUserRoleDto
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string CurrentRole { get; set; }
    public List<string> AllRoles { get; set; }
    public string SelectedRole { get; set; }
}
