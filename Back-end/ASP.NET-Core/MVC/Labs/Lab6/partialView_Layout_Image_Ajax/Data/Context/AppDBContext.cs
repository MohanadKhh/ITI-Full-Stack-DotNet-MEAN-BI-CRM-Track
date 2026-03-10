using Microsoft.EntityFrameworkCore;
using partialView_Layout_Image_Ajax.Models;

namespace partialView_Layout_Image_Ajax.Data.Context
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = "Server=.\\SQLEXPRESS;DataBase=Products_Category_Lab6;Trusted_Connection=true;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Books" },
                new Category { Id = 4, Name = "Home Appliances" },
                new Category { Id = 5, Name = "Sports" }
            );

            modelBuilder.Entity<Product>().HasData(

            // Electronics
            new Product { Id = 1, Name = "Laptop", Description = "Gaming laptop", Price = 25000, Count = 5, CategoryId = 1 },
            new Product { Id = 2, Name = "Smartphone", Description = "Android phone", Price = 12000, Count = 10, CategoryId = 1 },
            new Product { Id = 3, Name = "Headphones", Description = "Wireless headphones", Price = 1500, Count = 15, CategoryId = 1 },
            new Product { Id = 4, Name = "Smart Watch", Description = "Fitness watch", Price = 3000, Count = 7, CategoryId = 1 },

            // Clothing
            new Product { Id = 5, Name = "T-Shirt", Description = "Cotton t-shirt", Price = 300, Count = 20, CategoryId = 2 },
            new Product { Id = 6, Name = "Jeans", Description = "Blue jeans", Price = 800, Count = 12, CategoryId = 2 },
            new Product { Id = 7, Name = "Jacket", Description = "Winter jacket", Price = 1500, Count = 6, CategoryId = 2 },
            new Product { Id = 8, Name = "Sneakers", Description = "Running shoes", Price = 1200, Count = 9, CategoryId = 2 },

            // Books
            new Product { Id = 9, Name = "C# Book", Description = "Learn C#", Price = 500, Count = 10, CategoryId = 3 },
            new Product { Id = 10, Name = "Java Book", Description = "Spring Boot guide", Price = 600, Count = 8, CategoryId = 3 },
            new Product { Id = 11, Name = "Data Science Book", Description = "Machine Learning basics", Price = 750, Count = 5, CategoryId = 3 },
            new Product { Id = 12, Name = "Algorithms Book", Description = "DSA concepts", Price = 650, Count = 4, CategoryId = 3 },

            // Home
            new Product { Id = 13, Name = "Microwave", Description = "800W microwave", Price = 4000, Count = 3, CategoryId = 4 },
            new Product { Id = 14, Name = "Refrigerator", Description = "Double door fridge", Price = 15000, Count = 2, CategoryId = 4 },
            new Product { Id = 15, Name = "Washing Machine", Description = "Automatic washer", Price = 10000, Count = 4, CategoryId = 4 },
            new Product { Id = 16, Name = "Air Conditioner", Description = "1.5 HP AC", Price = 18000, Count = 3, CategoryId = 4 },

            // Sports
            new Product { Id = 17, Name = "Football", Description = "FIFA standard ball", Price = 400, Count = 14, CategoryId = 5 },
            new Product { Id = 18, Name = "Tennis Racket", Description = "Professional racket", Price = 2000, Count = 5, CategoryId = 5 },
            new Product { Id = 19, Name = "Padel Racket", Description = "Carbon fiber padel", Price = 2500, Count = 6, CategoryId = 5 },
            new Product { Id = 20, Name = "Dumbbells", Description = "10kg pair", Price = 900, Count = 8, CategoryId = 5 }
        );
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
