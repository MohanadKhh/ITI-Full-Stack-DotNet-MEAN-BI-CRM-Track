using Microsoft.AspNetCore.Mvc;
using Products_E_Commerce.Models;

namespace Products_E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = Guid.NewGuid(), Title = "Smart Phone", Description = "Android 8GB RAM", Price = 5000, Count = 100 },
            new Product { Id = Guid.NewGuid(), Title = "Laptop", Description = "Core i7 16GB RAM", Price = 15000, Count = 50 },
            new Product { Id = Guid.NewGuid(), Title = "Headphones", Description = "Wireless Bluetooth", Price = 800, Count = 200 },
            new Product { Id = Guid.NewGuid(), Title = "Smart Watch", Description = "Fitness Tracking Watch", Price = 1200, Count = 120 },
            new Product { Id = Guid.NewGuid(), Title = "Tablet", Description = "10 inch Display", Price = 7000, Count = 70 },
            new Product { Id = Guid.NewGuid(), Title = "Keyboard", Description = "Mechanical Keyboard", Price = 600, Count = 150 },
            new Product { Id = Guid.NewGuid(), Title = "Mouse", Description = "Wireless Mouse", Price = 300, Count = 180 },
            new Product { Id = Guid.NewGuid(), Title = "Monitor", Description = "24 inch Full HD", Price = 4000, Count = 40 },
            new Product { Id = Guid.NewGuid(), Title = "Printer", Description = "Color Inkjet Printer", Price = 3500, Count = 30 },
            new Product { Id = Guid.NewGuid(), Title = "Power Bank", Description = "20000mAh Fast Charge", Price = 900, Count = 250 }
        };
        public IActionResult Index()
        {
            return View("GetAll", products);
        }

        public IActionResult GetAll()
        {
            return View(products);
        }

        public IActionResult GetById(Guid Id)
        {
            var product = products.FirstOrDefault(p => p.Id == Id);
            if(product == null)
                return NotFound();
            return View(product);
        }
    }
}
