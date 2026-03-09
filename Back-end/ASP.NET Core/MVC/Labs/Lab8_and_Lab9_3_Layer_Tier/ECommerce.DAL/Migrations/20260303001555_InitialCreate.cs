using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Electronics" },
                    { 2, false, "Clothing" },
                    { 3, false, "Books" },
                    { 4, false, "Home Appliances" },
                    { 5, false, "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "Description", "ExpiryDate", "Image", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 5, "Gaming laptop", new DateOnly(2028, 1, 1), null, false, "Laptop", 25000m },
                    { 2, 1, 10, "Android phone", new DateOnly(2027, 6, 1), null, false, "Smartphone", 12000m },
                    { 3, 1, 15, "Wireless headphones", new DateOnly(2027, 3, 1), null, false, "Headphones", 1500m },
                    { 4, 1, 7, "Fitness watch", new DateOnly(2027, 8, 1), null, false, "Smart Watch", 3000m },
                    { 5, 2, 20, "Cotton t-shirt", new DateOnly(2026, 12, 1), null, false, "T-Shirt", 300m },
                    { 6, 2, 12, "Blue jeans", new DateOnly(2027, 5, 1), null, false, "Jeans", 800m },
                    { 7, 2, 6, "Winter jacket", new DateOnly(2027, 11, 1), null, false, "Jacket", 1500m },
                    { 8, 2, 9, "Running shoes", new DateOnly(2027, 9, 1), null, false, "Sneakers", 1200m },
                    { 9, 3, 10, "Learn C#", new DateOnly(2029, 1, 1), null, false, "C# Book", 500m },
                    { 10, 3, 8, "Spring Boot guide", new DateOnly(2029, 6, 1), null, false, "Java Book", 600m },
                    { 11, 3, 5, "Machine Learning basics", new DateOnly(2029, 3, 1), null, false, "Data Science Book", 750m },
                    { 12, 3, 4, "DSA concepts", new DateOnly(2029, 5, 1), null, false, "Algorithms Book", 650m },
                    { 13, 4, 3, "800W microwave", new DateOnly(2028, 2, 1), null, false, "Microwave", 4000m },
                    { 14, 4, 2, "Double door fridge", new DateOnly(2028, 7, 1), null, false, "Refrigerator", 15000m },
                    { 15, 4, 4, "Automatic washer", new DateOnly(2028, 4, 1), null, false, "Washing Machine", 10000m },
                    { 16, 4, 3, "1.5 HP AC", new DateOnly(2028, 9, 1), null, false, "Air Conditioner", 18000m },
                    { 17, 5, 14, "FIFA standard ball", new DateOnly(2027, 2, 1), null, false, "Football", 400m },
                    { 18, 5, 5, "Professional racket", new DateOnly(2027, 10, 1), null, false, "Tennis Racket", 2000m },
                    { 19, 5, 6, "Carbon fiber padel", new DateOnly(2027, 12, 1), null, false, "Padel Racket", 2500m },
                    { 20, 5, 8, "10kg pair", new DateOnly(2027, 4, 1), null, false, "Dumbbells", 900m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
