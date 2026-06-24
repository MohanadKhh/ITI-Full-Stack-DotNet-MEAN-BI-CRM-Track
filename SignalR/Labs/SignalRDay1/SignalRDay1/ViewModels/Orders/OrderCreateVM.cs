namespace SignalRDay1.ViewModels.Orders
{
    public class OrderCreateVM
    {
        public string Name { get; set; } = string.Empty;
        public string Item { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
    }
}
