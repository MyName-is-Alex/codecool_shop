using System.Linq;
using Codecool.CodecoolShop.DAL;
using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop;

public static class Extensions
{
    public static IQueryable<Product> GetCompleteProducts(this CodecoolShopContext context)
    {
        return context.Product
            .Include(b => b.ProductCategory)
            .Include(c => c.Supplier);
    }

    public static IQueryable<ItemModel> GetCompleteCart(this CodecoolShopContext context)
    {
        return context.ItemModel
            .Include(b => b.Product)
            .Include(c => c.Product.ProductCategory)
            .Include(d => d.Product.Supplier);
    }
}