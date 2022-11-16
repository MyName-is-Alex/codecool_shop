using Codecool.CodecoolShop.DAL;
using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Daos.Implementations.Database;

public class ProductDaoDatabase : IProductDao
{
    private CodecoolShopContext _context;
    private ILogger _logger;

    public ProductDaoDatabase(ILogger<ProductDaoDatabase> logger, CodecoolShopContext context)
    {
        _context = context;
        _logger = logger;
    }

    public void Add(Product item)
    {
        _logger.LogInformation("Db before update:" + _context.Product.Count());

        _context.Product.Add(item);
        _context.SaveChanges();

        _logger.LogInformation("Db after update:" + _context.Product.Count().ToString());
    }

    public void Remove(int id)
    {
        var productToRemove = _context.Product.Single(x => x.Id == id);
        _context.Product.Remove(productToRemove);
        _context.SaveChanges();
    }

    public Product Get(int id)
    {
        return _context.Product.Single(x => x.Id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.GetCompleteProducts();
    }

    public IEnumerable<Product> GetBy(Supplier supplier)
    {
        return _context.GetCompleteProducts().Where(x => x.Supplier == supplier);
    }

    public IEnumerable<Product> GetBy(ProductCategory productCategory)
    {
        return _context.GetCompleteProducts().Where(x => x.ProductCategory == productCategory);
    }
}