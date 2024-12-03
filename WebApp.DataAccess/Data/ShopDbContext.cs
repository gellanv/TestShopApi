using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Entities;

namespace WebApp.DataAccess.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(100);
                entity.Property(c => c.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(100);
                entity.Property(c => c.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(100);
                entity.Property(c => c.BirthDate)
                    .HasColumnName("birth_date")
                    .IsRequired();
                entity.Property(c => c.RegistrationDate)
                    .HasColumnName("registration_date")
                    .IsRequired();

                entity.HasMany(c => c.Purchases)
                    .WithOne(p => p.Customer)
                    .HasForeignKey(p => p.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("purchase");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.PurchaseDate)
                    .HasColumnName("purchase_date")
                    .IsRequired();

                entity.HasMany(p => p.PurchaseProducts)
                    .WithOne(pi => pi.Purchase)
                    .HasForeignKey(pi => pi.PurchaseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PurchaseProduct>(entity =>
            {
                entity.ToTable("purchase_item");
                entity.HasKey(pi => pi.Id);

                entity.Property(pi => pi.Quantity)
                    .IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.SKU)
                    .IsRequired();
                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18, 2)");

                entity.HasIndex(p => p.SKU)
                    .IsUnique();

                entity.HasMany(p => p.PurchaseItems)
                    .WithOne(pi => pi.Product)
                    .HasForeignKey(pi => pi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.CategoryName)
                    .HasColumnName("category_name")
                    .IsRequired();

                entity.HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
