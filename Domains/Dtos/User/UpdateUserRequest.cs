using Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Dtos.User;

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserTypeEnum UserType { get; set; } = UserTypeEnum.None;
}
