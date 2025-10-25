using Domains.Dtos.User;
using Domains.Entities;
using Domains.Enums;
using Domains.Interfaces;
using Infrstractures;
using Mapster;

namespace Services;

public class UserService : IUser
{
    private static List<User> _userStore = default!;

    public UserService()
    {
        if (_userStore == null)
        {
            _userStore = new List<User>();
        }
    }


    /// <summary>
    /// This method adds a new user to the in-memory user store after validating the input data.
    /// </summary> 
    /// <returns>return</returns>
    public OpStatusEnum Add(AddUserRequest request)
    {
        try
        {
            var user = request.Adapt<User>();

            var result = DataValidation(user, false);
            if (result)
            {
                user.Password = Encryption.Hash(user.Password);
                user.Id = GetGeneratedUserId();

                _userStore.Add(user);

                return OpStatusEnum.Success;
            }
            return OpStatusEnum.AlreadyExists;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private int GetGeneratedUserId()
    {
        if (_userStore == null || !_userStore.Any() || _userStore.Count == 0)
            return 1;

        return _userStore.Max(u => u.Id) + 1;
    }

    /// <summary>
    /// This method updates an existing user's details in the in-memory user store after validating the input data.
    /// </summary> 
    /// <returns>return</returns>
    public OpStatusEnum Update(UpdateUserRequest request)
    {
        try
        {
            var user = request.Adapt<User>();

            var result = DataValidation(user, true);
            if (!result)
                return OpStatusEnum.Error;

            var existingUser = _userStore.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.EmailAddress = request.EmailAddress;
                existingUser.FullName = request.FullName;
                return OpStatusEnum.Success;
            }
            return OpStatusEnum.Error;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// This method retrieves a user by their ID from the in-memory user store.
    /// </summary>
    /// <param name="userId">set user id- int value</param>
    /// <returns>return</returns>
    public User? GetById(int userId)
    {
        if (userId <= 0)
            return null;

        return _userStore.Where(u => u.Id == userId && !u.IsDeleted)
            .FirstOrDefault();

    }

    /// <summary>
    /// this method marks a user as deleted in the in-memory user store based on their ID.
    /// </summary>
    /// <param name="userId">set user id- int value</param>
    /// <returns>return</returns>
    public OpStatusEnum Delete(int userId)
    {
        try
        {
            var user = GetById(userId);
            if (user == null)
                return OpStatusEnum.NotFound;

            user.IsDeleted = true;
            return OpStatusEnum.Success;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// This method retrieves all non-deleted users from the in-memory user store.
    /// </summary>
    /// <returns>return all users</returns>
    public List<User> GetAll()
    {
        try
        {
            var users = _userStore.Where(u => !u.IsDeleted)
                .OrderByDescending(q => q.Id)
                .ToList();
            return users;
        }
        catch (Exception)
        {

            throw;
        }
    }

    private bool DataValidation(User data, bool isUpdate)
    {
        if (isUpdate)
        {
            if (data.Id <= 0)
                return false;
        }

        if (string.IsNullOrEmpty(data.FullName))
            return false;
        if (string.IsNullOrEmpty(data.EmailAddress))
            return false;
        if (string.IsNullOrEmpty(data.Password))
            return false;
        if (data.UserType == UserTypeEnum.None)
            return false;

        var isUserExists = _userStore.Any(q => q.EmailAddress == data.EmailAddress);
        if (isUserExists)
            return false;

        return true;
    }
}
