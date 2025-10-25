using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Dtos.User;

public class UserUpdateMode
{
    public Domains.Entities.User? UserInfo { get; set; }
    public List<Domains.Entities.User> Users { get; set; }
    public bool IsUpdateMode { get; set; } = false;
}
