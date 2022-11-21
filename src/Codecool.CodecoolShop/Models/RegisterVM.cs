using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class RegisterVM
{
    [Required]
    public string Email { get; set; }

    [Required(ErrorMessage = "Required"), DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Password doesn't match:(")]
    public string ConfirmPassword { get; set; }
}