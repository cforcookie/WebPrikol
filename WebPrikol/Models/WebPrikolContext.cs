using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Staff>()
                .HasOne(p => p.Positions)
                .WithMany(b => b.Staffs)
                .HasForeignKey(p => p.PositionForigenKey);
            modelBuilder.Entity<Orders>()
                .HasOne(p => p.Staff)
                .WithMany(b => b.Orders)
                .HasForeignKey(p => p.StaffsForigenKey);
            modelBuilder.Entity<Orders>()
                .HasOne(p => p.Products)
                .WithMany(b => b.Orders)
                .HasForeignKey(p => p.ProductsForigenKey);
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Products)
                .WithMany(b => b.Purchase)
                .HasForeignKey(p => p.ProductsForigenKey);


        }

    }
}
