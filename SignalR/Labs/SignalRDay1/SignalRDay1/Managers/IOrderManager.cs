using SignalRDay1.Models;
using SignalRDay1.ViewModels.Orders;

namespace SignalRDay1.Managers
{
    public interface IOrderManager
    {
        Order CreateOrder(OrderCreateVM orderCreateVM);
        List<Order> GetOrders();
    }
}