using System.Linq;
using Codecool.CodecoolShop.DAL;
using Codecool.CodecoolShop.Models;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Daos.Implementations.Database;

public class UserDaoDatabase
{
    private ILogger<UserDaoDatabase> _logger;
    private CodecoolShopContext _context;

    public UserDaoDatabase(ILogger<UserDaoDatabase> logger, CodecoolShopContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void Add(AppUser user)
    {
        if (!_context.AppUser.Contains(user))
            _context.AppUser.Add(user);

        _context.SaveChanges();
    }

    public AppUser? GetUser(string email)
    {
        var temp = _context.AppUser.FirstOrDefault(x => x.Email == email);
        return temp;
    }

    public string GetPassword(string email)
    {
        var temp = _context.AppUser.FirstOrDefault(x => x.Email == email).Password;
        return temp;
    }
}