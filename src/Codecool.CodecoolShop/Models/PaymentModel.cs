using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class PaymentModel
{
    [Required(ErrorMessage = "Required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Required")]
    [EmailAddress(ErrorMessage = "Email is not valid!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Required")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Required")]
    public string City { get; set; }

    [Required(ErrorMessage = "Required")]
    public string ZipCode { get; set; }

    [Required(ErrorMessage = "Required")]
    public string NameOnCard { get; set; }

    [Required(ErrorMessage = "Required")]
    [CreditCard(ErrorMessage = "Credit card not valid!")]
    public string CreditCardNumber { get; set; }

    [Required(ErrorMessage = "Required")]
    public string ExpirationDate { get; set; }

    [Required(ErrorMessage = "Required")]
    public string Cvv { get; set; }
}