using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class PaymentModel
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Zip { get; set; }

    [Required]
    public string NameOnCard { get; set; }

    [Required]
    public string CreditCardNumber { get; set; }

    [Required]
    public string ExpirationDate { get; set; }

    [Required]
    public string Cvv { get; set; }
}