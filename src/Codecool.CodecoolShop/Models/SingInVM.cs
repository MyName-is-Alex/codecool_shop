using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class SingInVM
{
    [Required]
    public string UsernameOrEmail
    {
        get;
        set;
    }
    [Required, DataType(DataType.Password)]
    public string Password
    {
        get;
        set;
    }
    public bool RememberMe
    {
        get;
        set;
    }
}