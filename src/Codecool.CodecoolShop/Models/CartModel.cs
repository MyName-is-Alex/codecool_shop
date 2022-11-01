using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models;

public class CartModel
{
    public List<ItemModel> Items { get; set; }
    public decimal TotalPrice { get; set; }
}