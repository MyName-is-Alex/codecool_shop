using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
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
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            return this.productCategoryDao.Get(categoryId);
        }

        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return productCategoryDao.GetAll();
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return supplierDao.GetAll();
        }
    }
}
