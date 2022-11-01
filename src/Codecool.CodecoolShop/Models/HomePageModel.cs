using Codecool.CodecoolShop.Daos.Implementations;
using System.Collections;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models;

public class HomePageModel
{
    public List<Supplier> Suppliers { get; set; }
    public List<ProductCategory> Categories { get; set; }
    public List<Product> Products { get; set; }
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
}