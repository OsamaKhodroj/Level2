using Domains.Enums;

namespace Domains.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserTypeEnum UserType { get; set; } = UserTypeEnum.None;
}
