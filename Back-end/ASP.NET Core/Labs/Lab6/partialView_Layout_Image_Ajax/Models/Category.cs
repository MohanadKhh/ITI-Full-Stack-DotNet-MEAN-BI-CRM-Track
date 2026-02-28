namespace partialView_Layout_Image_Ajax.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Product>? Products { get; set; }
    }
}
