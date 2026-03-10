namespace ECommerce.BLL
{
    public class ProductsDropdownVM
    {
        public int Id { get; set; }
        public IEnumerable<ProductIdName>? Products { get; set; }
    }
}
