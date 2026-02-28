using partialView_Layout_Image_Ajax.Models;
using System.ComponentModel.DataAnnotations;

namespace partialView_Layout_Image_Ajax.ViewModels
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
