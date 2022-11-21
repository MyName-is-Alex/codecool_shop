using System.Collections.Generic;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos.Implementations.Database;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers
{
    public class AuthenticationController : BaseController
    {
        public UserService UserService { get; set; }
        private CartService _cartService { get; set; }
        private readonly ILogger<ProductController> _logger;

        public AuthenticationController(ILogger<ProductController> logger, UserDaoDatabase userDao, CartDaoDatabase cartDao)
        {
            UserService = new UserService(userDao);
            _logger = logger;
            _cartService = new CartService(cartDao);
        }

        public IActionResult Register()
        {
            return View("RegisterIndex");
        }

        [HttpPost]
        public IActionResult Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View("RegisterIndex");

            AppUser newUser = new() { Email = register.Email, Password = register.Password };

            if (UserService.UserExists(register.Email))
            {
                ModelState.AddModelError(nameof(register.Email), "User already exists");
                return View("RegisterIndex");
            }

            UserService.AddNewUser(newUser);
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View("SignInIndex");
        }

        [HttpPost]
        public IActionResult Login(SingInVM signIn)
        {
            if (!ModelState.IsValid) return View("SignInIndex");

            AppUser user = new() { Email = signIn.Email, Password = signIn.Password };

            if (!UserService.UserExists(signIn.Email))
            {
                ModelState.AddModelError(nameof(signIn.Email), "You should consider registering...");
                return View("SignInIndex");
            }

            if (!UserService.ValidatePassword(signIn.Email, signIn.Password))
            {
                ModelState.AddModelError(nameof(signIn.Password), "Nice try, you hacker!");
                return View("SignInIndex");
            }

            SessionHelper.SetUserAsJson(HttpContext.Session, "user", signIn.Email);

            // check if user already has a cart saved
            List<ItemModel> cartDb = _cartService.GetCartForUser(signIn.Email);

            // associate already existing cart with the new user
            var cart = SessionHelper.GetObjectFromJson<List<ItemModel>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                cart.ForEach(x => x.AppUserEmail = signIn.Email);
                cart.AddRange(cartDb);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartDb);
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
