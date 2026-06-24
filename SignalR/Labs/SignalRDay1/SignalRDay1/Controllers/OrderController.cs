using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDay1.Hubs;
using SignalRDay1.Managers;
using SignalRDay1.ViewModels.Orders;
using System.Threading.Tasks;

namespace SignalRDay1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IHubContext<OrderHub> _hubContext;

        public OrderController(IOrderManager orderManager, IHubContext<OrderHub> hubContext)
        {
            _orderManager = orderManager;
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _orderManager.GetOrders();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var order = _orderManager.CreateOrder(model);
                await _hubContext.Clients.All.SendAsync("NewOrder", order);
            }

            return RedirectToAction("Index");
        }
    }
}
