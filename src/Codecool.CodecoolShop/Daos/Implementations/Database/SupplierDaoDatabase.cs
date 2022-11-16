using Codecool.CodecoolShop.DAL;
using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations.Database;

public class SupplierDaoDatabase : ISupplierDao
{
    private CodecoolShopContext _context;

    public SupplierDaoDatabase(CodecoolShopContext context)
    {
        _context = context;
    }

    public void Add(Supplier item)
    {
        _context.Supplier.Add(item);
        _context.SaveChanges();
    }

    public void Remove(int id)
    {
        var supplierToRemove = _context.Supplier.Single(x => x.Id == id);
        _context.Supplier.Remove(supplierToRemove);
        _context.SaveChanges();
    }

    public Supplier Get(int id)
    {
        return _context.Supplier.Single(x => x.Id == id);
    }

    public IEnumerable<Supplier> GetAll()
    {
        return _context.Supplier;
    }

}