namespace Product_Category_CRUD_Validations.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateOnly? ExpiryDate { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual Category? Category { get; set; }
    }
}
