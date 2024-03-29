﻿using System;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : BaseController
    {
        private readonly IProductDao _productDao;
        public CartController(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ItemModel>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<ItemModel>();
            }

            CartModel cartModel = new CartModel { Items = cart, TotalPrice = cart.Sum(x => x.Product.DefaultPrice * x.Quantity) };

            return View(cartModel);
        }

        public JsonResult Buy(int id)
        {
            // move to service
            Product product = _productDao.Get(id);
            string userEmail = SessionHelper.GetUserFromJson(HttpContext.Session, "user");

            if (SessionHelper.GetObjectFromJson<List<ItemModel>>(HttpContext.Session, "cart") == null)
            {
                List<ItemModel> cart = new List<ItemModel>();
                cart.Add(new ItemModel { AppUserEmail = userEmail, ProductId = product.Id, Product = product, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return Json(cart);
            }
            else
            {
                List<ItemModel> cart = SessionHelper.GetObjectFromJson<List<ItemModel>>(HttpContext.Session, "cart");
                int index = getIndexOfProduct(id, cart);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new ItemModel { AppUserEmail = userEmail, ProductId = product.Id, Product = product, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return Json(cart);
            }
        }

        public JsonResult Remove(int id)
        {
            List<ItemModel> cart = SessionHelper.GetObjectFromJson<List<ItemModel>>(HttpContext.Session, "cart");
            int index = getIndexOfProduct(id, cart);
            if (cart[index].Quantity > 1)
            {
                cart[index].Quantity--;
            }
            else
            {
                cart.RemoveAt(index);
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return Json(cart);
        }

        public JsonResult CartPreview()
        {
            List<ItemModel> cart;
            try
            {
                cart = SessionHelper.GetObjectFromJson<List<ItemModel>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
            }
            catch (ArgumentNullException)
            {
                cart = new List<ItemModel>();
            }

            return Json(cart);
        }

        private int getIndexOfProduct(int id, List<ItemModel> cart)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
