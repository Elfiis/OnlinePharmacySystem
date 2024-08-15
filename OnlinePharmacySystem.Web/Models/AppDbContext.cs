using Microsoft.EntityFrameworkCore;
using onlinePharmacySystem.Web.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace onlinePharmacySystem.Web.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BlogPosts> BlogPosts { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<FAQs> FAQs { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Pharmacies> Pharmacies { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys
            modelBuilder.Entity<Basket>()
                .HasKey(b => b.BasketID);

            modelBuilder.Entity<BlogPosts>()
                .HasKey(b => b.BlogPostID);

            modelBuilder.Entity<Brands>()
                .HasKey(b => b.BrandID);

            modelBuilder.Entity<Categories>()
                .HasKey(c => c.CategoryID);

            modelBuilder.Entity<Deliveries>()
                .HasKey(d => d.DeliveryID);

            modelBuilder.Entity<FAQs>()
                .HasKey(f => f.FaqID);

            modelBuilder.Entity<OrderDetails>()
                .HasKey(o => o.OrderDetailID);

            modelBuilder.Entity<Orders>()
                .HasKey(o => o.OrderID);

            modelBuilder.Entity<Payments>()
                .HasKey(p => p.PaymentID);

            modelBuilder.Entity<Pharmacies>()
                .HasKey(p => p.PharmacyID);

            modelBuilder.Entity<Products>()
                .HasKey(p => p.ProductID);

            modelBuilder.Entity<Roles>()
                .HasKey(r => r.RoleID);

            modelBuilder.Entity<Suppliers>()
                .HasKey(s => s.SupplierID);

            modelBuilder.Entity<Users>()
                .HasKey(u => u.UserID);

            // Define relationships with restricted cascade delete
            //modelBuilder.Entity<Users>()
            //    .HasOne(u => u.UserRole)
            //    .WithMany()
            //    .HasForeignKey(u => u.UserRoleID)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductCategory)
                .WithMany()
                .HasForeignKey(p => p.ProductCategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.ProductBrandID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductSupplier)
                .WithMany()
                .HasForeignKey(p => p.ProductSupplierID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductFAQs)
                .WithMany()
                .HasForeignKey(p => p.ProductFAQsID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductPharmacies)
                .WithMany(p => p.PharmacyProducts)
                .HasForeignKey(p => p.ProductPharmaciesID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.OrderUser)
                .WithMany()
                .HasForeignKey(o => o.OrderUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.OrderPayment)
                .WithMany()
                .HasForeignKey(o => o.OrderPaymentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.OrderPharmacy)
                .WithMany()
                .HasForeignKey(o => o.OrderPharmacyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.OrderDelivery)
                .WithMany()
                .HasForeignKey(o => o.OrderDeliveryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Basket>()
                .HasOne(b => b.BasketUser)
                .WithMany()
                .HasForeignKey(b => b.BasketUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Fix OrderDetails foreign keys to avoid cascade paths
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.OrderDetailOrder)
                .WithMany()
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.OrderDetailProduct)
                .WithMany()
                .HasForeignKey(od => od.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Basket and OrderDetails relationships
            modelBuilder.Entity<Basket>()
                .HasMany(b => b.BasketOrderDetails)
                .WithOne()
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal properties
            modelBuilder.Entity<OrderDetails>()
                .Property(o => o.TaxRate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetails>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Products>()
                .Property(p => p.ProductPrice)
                .HasColumnType("decimal(18,2)");
        }
    }
}