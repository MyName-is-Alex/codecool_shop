using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Codecool.CodecoolShop.DAL;

namespace Codecool.CodecoolShop.Daos.Implementations.Database;

public class CartDaoDatabase
{

    private CodecoolShopContext _context;

    public CartDaoDatabase(CodecoolShopContext context)
    {
        _context = context;
    }

    public void Add(ItemModel item, string user)
    {
        item.Product = null;
        if (_context.ItemModel.Where(x => x.AppUserEmail == user).Select(x => x.ProductId).Contains(item.ProductId))
        {
            _context.ItemModel.Where(x => x.AppUserEmail == user).First(x => x.ProductId == item.ProductId).Quantity++;
        }
        else
        {
            _context.ItemModel.Add(item);
        }

        _context.SaveChanges();
    }

    public List<ItemModel> Get(string user)
    {
       return _context.GetCompleteCart().Where(x => x.AppUserEmail == user).ToList();
    }
}
