using System.Collections.Generic;
using Codecool.CodecoolShop.DAL;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations.Database;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services;

public class CartService
{
    private CartDaoDatabase _cartDao;

    public CartService(CartDaoDatabase cartDao)
    {
        _cartDao = cartDao;
    }

    public void AddCartToDb(List<ItemModel> cart, string user)
    {
        foreach (var item in cart)
        {
            _cartDao.Add(item, user);
        }
    }

    public List<ItemModel> GetCartForUser(string user)
    {
        return _cartDao.Get(user);
    }
}