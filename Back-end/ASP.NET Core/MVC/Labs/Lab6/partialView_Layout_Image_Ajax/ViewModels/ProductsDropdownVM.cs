using Microsoft.AspNetCore.Mvc.Rendering;

namespace partialView_Layout_Image_Ajax.ViewModels
{
    public class ProductsDropdownVM
    {
        public int Id {  get; set; }
        public List<SelectListItem>? Products { get; set; }
    }
}
