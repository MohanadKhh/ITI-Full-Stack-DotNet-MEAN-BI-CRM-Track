using Microsoft.AspNetCore.Mvc.Rendering;

namespace Product_Category_CRUD.ViewModels
{
    public class ProductCreateVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<SelectListItem>? Categories { get; set; }
    }
}
