namespace ECommerce.BLL
{
    public class CategorySearchVM
    {
        public int Id { get; set; }
        public IEnumerable<CategoryVM>? Categories { get; set; }
    }
}
