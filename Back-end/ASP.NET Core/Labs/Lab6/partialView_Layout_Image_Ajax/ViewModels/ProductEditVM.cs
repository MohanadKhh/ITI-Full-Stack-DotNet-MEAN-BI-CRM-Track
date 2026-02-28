using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using partialView_Layout_Image_Ajax.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace partialView_Layout_Image_Ajax.ViewModels
{
    public class ProductEditVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3, ErrorMessage = "Name must be at least 3 character")]
        [Remote(action: "IsNameUniqueness", controller: "Product", AdditionalFields = "Id", ErrorMessage = "Name is already exists")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(1, 1_000_000_000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 1_000)]
        public int Count { get; set; }

        [DataType(DataType.Date)]
        [ExpiryDateValidation]
        public DateOnly ExpiryDate { get; set; }

        public string? ImagePath { get; set; }

        public IFormFile ImageFile { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<SelectListItem>? Categories { get; set; }
    }
}
