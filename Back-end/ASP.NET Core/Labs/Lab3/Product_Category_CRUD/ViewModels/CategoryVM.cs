using Product_Category_CRUD.Models;

namespace Product_Category_CRUD.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ProductCounts { get; set; }
        public ICollection<Product>? products { get; set; }
    }
}
