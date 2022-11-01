using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderConfirmation(PaymentModel paymentModel)
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
    }

}
