using Microsoft.EntityFrameworkCore;
using SignalRDay1.Models;

namespace SignalRDay1.Data
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Orders");

                entity.ToTable("Orders");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Item).HasColumnName("item");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
