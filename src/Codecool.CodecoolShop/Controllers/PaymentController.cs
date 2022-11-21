using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.DAL;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations.Database;
using Codecool.CodecoolShop.Services;

namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : BaseController
    {
        private CartService cartService;

        public PaymentController(CartDaoDatabase cartDao)
        {
            cartService = new CartService(cartDao);
        }

        public ActionResult Index()
        {
            if (SessionHelper.GetUserFromJson(HttpContext.Session, "user") != null)
            {
                string user = SessionHelper.GetUserFromJson(HttpContext.Session, "user");
                var cart = SessionHelper.GetObjectFromJson<List<ItemModel>>(HttpContext.Session, "cart");
                cartService.AddCartToDb(cart, user);
            }

            return View();
        }

        public ActionResult OrderConfirmation(PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                var cart = SessionHelper.GetObjectFromJson<List<ItemModel>>(HttpContext.Session, "cart");
                if (cart == null)
                {
                    cart = new List<ItemModel>();
                }

                CartModel cartModel = new CartModel
                    { Items = cart, TotalPrice = cart.Sum(x => x.Product.DefaultPrice * x.Quantity) };

                ViewBag.TotalPrice = cartModel.TotalPrice;
                ViewBag.PaymentModel = paymentModel;
                return View();
            }

            return View("Index");

        }
    }

}
