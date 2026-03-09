namespace Product_Category_CRUD.ViewModels
{
    public class ProductReadVM
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
    }
}
