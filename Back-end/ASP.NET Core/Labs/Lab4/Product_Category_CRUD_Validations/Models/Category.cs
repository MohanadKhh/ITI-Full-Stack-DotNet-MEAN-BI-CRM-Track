namespace Product_Category_CRUD_Validations.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Product>? Products { get; set; }
    }
}
