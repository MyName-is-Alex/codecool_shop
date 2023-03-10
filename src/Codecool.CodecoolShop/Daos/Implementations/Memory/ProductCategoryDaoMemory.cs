using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations.Memory
{
    class ProductCategoryDaoMemory : IProductCategoryDao
    {
        private List<ProductCategory> data = new List<ProductCategory>();
        public static ProductCategoryDaoMemory instance = null;

        private ProductCategoryDaoMemory()
        {
        }

        public static ProductCategoryDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductCategoryDaoMemory();
            }

            return instance;
        }

        public void Add(ProductCategory item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(Get(id));
        }

        public ProductCategory Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return data;
        }
    }
}
