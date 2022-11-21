using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class SingInVM
{
    [Required]
    public string Email { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
}