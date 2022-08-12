using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Data.Models.Models
{
    public class Category
    {
        public Category()
        {
            CategoryProducts = new HashSet<CategoryProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
