using Domains.Dtos.User;
using Domains.Entities;
using Domains.Enums;

namespace Domains.Interfaces;

public interface IUser
{
    OpStatusEnum Add(AddUserRequest request);
    OpStatusEnum Update(UpdateUserRequest request);
    OpStatusEnum Delete(int userId);
    User? GetById(int userId);
    List<User> GetAll();
}
