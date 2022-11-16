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
}