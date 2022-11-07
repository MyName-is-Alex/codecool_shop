using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                    ProductCategoryDaoMemory.GetInstance(),
                    SupplierDaoMemory.GetInstance()
                );

            ProductCategoryDaoMemory.GetInstance();
        }

        public IActionResult Index()
        {
            IEnumerable<Product> displayProducts = ProductService.GetProductsForCategory(0);

            IEnumerable<ProductCategory> categories = ProductService.GetAllCategories();
            IEnumerable<Supplier> suppliers = ProductService.GetAllSuppliers();
            var homePageModel = new HomePageModel
            {
                Categories = categories.ToList(),
                Products = displayProducts.ToList(),
                Suppliers = suppliers.ToList(),
                CategoryId = 0,
                SupplierId = 0
            };

            return View(homePageModel);
        }

        public ActionResult FilteredProducts(int categoryId, int supplierId)
        {
            IEnumerable<Product> productsInCategory = ProductService.GetProductsForCategory(categoryId);
            IEnumerable<Product> productsBySupplier = ProductService.GetProductsForSupplier(supplierId);

            IEnumerable<Product> displayProducts = productsInCategory.Where(x => productsBySupplier.Contains(x));

            //UPDATE HOMEPAGE STATE
            return PartialView("_PartialIndex", displayProducts.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
