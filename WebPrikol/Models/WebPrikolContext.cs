using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace WebPrikol.Models
{
    public class WebPrikolContext : DbContext
    {
        public WebPrikolContext(DbContextOptions<WebPrikolContext> options)
            : base(options)
        {

        }
        public DbSet<Buyers> Buyers { get; set; } = null!;
        public DbSet<Orders> Orders { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Products> Products { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;
        public DbSet<Staff> Staffs { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                .HasOne(p => p.Buyers)
                .WithMany(b => b.Orders)
                .HasForeignKey(p => p.BuyersForigenKey);
        }
    }
}
