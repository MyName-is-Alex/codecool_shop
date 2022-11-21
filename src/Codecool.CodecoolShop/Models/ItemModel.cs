using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Codecool.CodecoolShop.Models;

public class ItemModel
{
    public int Id { get; set; }

    public string AppUserEmail { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public Product Product { get; set; }
}