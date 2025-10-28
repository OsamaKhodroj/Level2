using Domains.Enums;

namespace Domains.Dtos.User;

public class AddUserRequest
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserTypeEnum UserType { get; set; } = UserTypeEnum.None;
}
