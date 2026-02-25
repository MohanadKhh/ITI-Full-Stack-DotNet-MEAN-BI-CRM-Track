using Product_Category_CRUD_Validations.Models;
using System.ComponentModel.DataAnnotations;

namespace Product_Category_CRUD_Validations.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public required string Name { get; set; }

        [Required]
        public int ProductCounts { get; set; }
        public ICollection<Product>? products { get; set; }
    }
}
