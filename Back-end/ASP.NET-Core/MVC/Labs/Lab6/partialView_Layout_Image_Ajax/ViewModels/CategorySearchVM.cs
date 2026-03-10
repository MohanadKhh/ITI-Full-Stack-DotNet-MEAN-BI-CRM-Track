using Microsoft.AspNetCore.Mvc.Rendering;

namespace partialView_Layout_Image_Ajax.ViewModels
{
    public class CategorySearchVM
    {
        public int Id { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}
