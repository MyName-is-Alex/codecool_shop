<<<<<<< HEAD
using System.Collections.Generic;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 1bcbcd9d0b006f026dd209ed5e604879ac61ff9e
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
<<<<<<< HEAD
        private readonly ISupplierDao supplierDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierDao = supplierDao;
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            if (categoryId != 0)
            {
                ProductCategory category = this.productCategoryDao.Get(categoryId);
                return this.productDao.GetBy(category);
            }
            return productDao.GetAll();
        }

        public IEnumerable<Product> GetProductsForSupplier(int supplierId)
        {
            if (supplierId != 0)
            {
                Supplier supplier = this.supplierDao.Get((int)supplierId);
                return this.productDao.GetBy(supplier);
            }
            return productDao.GetAll();
=======

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
>>>>>>> 1bcbcd9d0b006f026dd209ed5e604879ac61ff9e
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            return this.productCategoryDao.Get(categoryId);
        }

<<<<<<< HEAD
        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return productCategoryDao.GetAll();
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return supplierDao.GetAll();
=======
        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = this.productCategoryDao.Get(categoryId);
            return this.productDao.GetBy(category);
>>>>>>> 1bcbcd9d0b006f026dd209ed5e604879ac61ff9e
        }
    }
}
