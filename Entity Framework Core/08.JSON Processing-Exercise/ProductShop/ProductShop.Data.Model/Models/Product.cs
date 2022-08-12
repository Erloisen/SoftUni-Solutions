using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Data.Models.Models
{
    public class Product
    {
        public Product()
        {
            CategoryProducts = new HashSet<CategoryProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(User))]
        public int SellerId { get; set; }
        public virtual User Seller { get; set; }


        [ForeignKey(nameof(User))]
        public int? BuyerId { get; set; }
        public virtual User Buyer { get; set; }

        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
