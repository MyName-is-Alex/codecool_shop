using Codecool.CodecoolShop.DAL;
using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations.Database;

public class ProductCategoryDaoDatabase : IProductCategoryDao
{
    private CodecoolShopContext _context;

    public ProductCategoryDaoDatabase(CodecoolShopContext context)
    {
        _context = context;
    }

    public void Add(ProductCategory item)
    {
        _context.ProductCategory.Add(item);
        _context.SaveChanges();
    }

    public void Remove(int id)
    {
        var categoryToRemove = _context.ProductCategory.Single(x => x.Id == id);
        _context.ProductCategory.Remove(categoryToRemove);
        _context.SaveChanges();
    }

    public ProductCategory Get(int id)
    {
        return _context.ProductCategory.SingleOrDefault(x => x.Id == id);
    }

    public IEnumerable<ProductCategory> GetAll()
    {
        return _context.ProductCategory;
    }
}