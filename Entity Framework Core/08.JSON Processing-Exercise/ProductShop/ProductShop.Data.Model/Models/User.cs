using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Data.Models.Models
{
    public class User
    {
        public User()
        {
            ProductsSold = new HashSet<Product>();
            ProductsBougth = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<Product> ProductsSold { get; set; }
        public virtual ICollection<Product> ProductsBougth { get; set; }
    }
}
