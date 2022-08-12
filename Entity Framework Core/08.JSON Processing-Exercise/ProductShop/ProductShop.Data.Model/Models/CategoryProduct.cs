using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Data.Models.Models
{
    public class CategoryProduct
    {
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
