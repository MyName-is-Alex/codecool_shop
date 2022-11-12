using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codecool.CodecoolShop.Models
{
    public class Product : BaseModel
    {
        public string Currency { get; set; }
        public decimal DefaultPrice { get; set; }
        public int ProductCategoryId { get; set; }
        public int SupplierId { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public Supplier Supplier { get; set; }
    }
}
