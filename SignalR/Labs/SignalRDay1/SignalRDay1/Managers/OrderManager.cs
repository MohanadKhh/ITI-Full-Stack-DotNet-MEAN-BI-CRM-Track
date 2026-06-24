using SignalRDay1.Data;
using SignalRDay1.Models;
using SignalRDay1.ViewModels.Orders;

namespace SignalRDay1.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly AppDbContext _context;
        public OrderManager(AppDbContext context)
        {
            _context = context;
        }

        public Order CreateOrder(OrderCreateVM orderCreateVM)
        {
            var order = new Order
            {
                Name = orderCreateVM.Name,
                Item = orderCreateVM.Item,
                Quantity = orderCreateVM.Quantity
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }
    }
}
