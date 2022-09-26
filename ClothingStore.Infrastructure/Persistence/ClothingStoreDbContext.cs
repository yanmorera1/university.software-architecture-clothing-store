using ClothingStore.Domain;
using ClothingStore.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Type = ClothingStore.Domain.Type;

namespace ClothingStore.Infrastructure.Persistence
{
    public class ClothingStoreDbContext : DbContext
    {
        public ClothingStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(od => od.OrderId);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(od => od.ProductId);
            modelBuilder.Entity<OrderDetail>()
                .Ignore(od => od.Id);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}
