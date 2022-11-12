using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class ProductCategory: BaseModel
    {
        public string Department { get; set; }

        public List<Product> Products { get; set; }
    }
}
