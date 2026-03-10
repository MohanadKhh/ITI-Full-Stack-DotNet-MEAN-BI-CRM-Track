using System.ComponentModel.DataAnnotations;

namespace ECommerce.BLL
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string Eamil {  get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password {  get; set; } = string.Empty;

        public bool RemeberMe { get; set; }
    }
}
