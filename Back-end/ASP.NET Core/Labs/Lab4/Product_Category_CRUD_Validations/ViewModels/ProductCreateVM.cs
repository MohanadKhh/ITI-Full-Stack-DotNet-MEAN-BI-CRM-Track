using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Category_CRUD_Validations.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace Product_Category_CRUD_Validations.ViewModels
{
    public class ProductCreateVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3, ErrorMessage = "Name must be at least 3 character")]
        [Remote(action: "IsNameUniqueness", controller:"Product", AdditionalFields = "Id", ErrorMessage = "Name is already exists")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(1,1_000_000_000)]
        public decimal Price { get; set; }

        [Required]
        public int Count { get; set; }

        [DataType (DataType.Date)]
        [ExpiryDateValidation]
        public DateOnly ExpiryDate { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<SelectListItem>? Categories { get; set; }
    }
}
