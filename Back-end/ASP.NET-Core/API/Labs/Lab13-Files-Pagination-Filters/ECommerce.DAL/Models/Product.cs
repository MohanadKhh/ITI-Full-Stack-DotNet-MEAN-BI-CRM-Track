using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECommerce.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateOnly? ExpiryDate { get; set; }

        [Column("Image")]
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; } = false;
        [JsonIgnore]
        public virtual Category? Category { get; set; }
    }
}
