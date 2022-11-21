using Codecool.CodecoolShop.Daos.Implementations.Database;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services;

public class UserService
{
    private UserDaoDatabase _userDao;

    public UserService(UserDaoDatabase userDao)
    {
        _userDao = userDao;
    }

    public bool UserExists(string email)
    {
        var temp = _userDao.GetUser(email) != null;
        return temp;
    }

    public bool ValidatePassword(string email, string enteredPassword)
    {
        var temp = _userDao.GetPassword(email);
        return temp == enteredPassword;
    }

    public void AddNewUser(AppUser user)
    {
        _userDao.Add(user);
    }
}