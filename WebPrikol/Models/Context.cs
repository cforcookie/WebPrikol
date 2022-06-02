using Microsoft.EntityFrameworkCore;

namespace WebPrikol.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }
        public DbSet<UserDto> UserDto { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Warehouse> Warehouses { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Basket> Baskets { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDto>()
                .HasOne(b => b.User)
                .WithOne(i => i.UserDto)
                .HasForeignKey<User>(b => b.UserDtoForeiginKey);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Warehouses)
                .WithMany()
                .HasForeignKey(p => p.WarehouseForeiginKey);

            modelBuilder.Entity<Basket>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductsForeiginKey);

            modelBuilder.Entity<Basket>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserForeiginKey);

        }

    }
}