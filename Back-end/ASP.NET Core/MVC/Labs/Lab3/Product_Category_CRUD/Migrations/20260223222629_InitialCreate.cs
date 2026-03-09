using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product_Category_CRUD.Migrations
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Books" },
                    { 4, "Home Appliances" },
                    { 5, "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 5, "Gaming laptop", "Laptop", 25000m },
                    { 2, 1, 10, "Android phone", "Smartphone", 12000m },
                    { 3, 1, 15, "Wireless headphones", "Headphones", 1500m },
                    { 4, 1, 7, "Fitness watch", "Smart Watch", 3000m },
                    { 5, 2, 20, "Cotton t-shirt", "T-Shirt", 300m },
                    { 6, 2, 12, "Blue jeans", "Jeans", 800m },
                    { 7, 2, 6, "Winter jacket", "Jacket", 1500m },
                    { 8, 2, 9, "Running shoes", "Sneakers", 1200m },
                    { 9, 3, 10, "Learn C#", "C# Book", 500m },
                    { 10, 3, 8, "Spring Boot guide", "Java Book", 600m },
                    { 11, 3, 5, "Machine Learning basics", "Data Science Book", 750m },
                    { 12, 3, 4, "DSA concepts", "Algorithms Book", 650m },
                    { 13, 4, 3, "800W microwave", "Microwave", 4000m },
                    { 14, 4, 2, "Double door fridge", "Refrigerator", 15000m },
                    { 15, 4, 4, "Automatic washer", "Washing Machine", 10000m },
                    { 16, 4, 3, "1.5 HP AC", "Air Conditioner", 18000m },
                    { 17, 5, 14, "FIFA standard ball", "Football", 400m },
                    { 18, 5, 5, "Professional racket", "Tennis Racket", 2000m },
                    { 19, 5, 6, "Carbon fiber padel", "Padel Racket", 2500m },
                    { 20, 5, 8, "10kg pair", "Dumbbells", 900m }
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
