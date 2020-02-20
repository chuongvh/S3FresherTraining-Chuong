using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace S3Train.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
                    : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductAdvertisement> ProductAdvertisements { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Description).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Amount).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.SKU).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Status).IsRequired();
            modelBuilder.Entity<Product>().HasMany(c => c.ProductImages).WithRequired(p => p.Product);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.Description).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.Status).IsRequired();
            modelBuilder.Entity<Category>().HasMany(s => s.Products).WithMany(c => c.Categories);

            modelBuilder.Entity<ProductAdvertisement>().ToTable("ProductAdvertisement");
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.EventUrl).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.EventUrlCaption).HasMaxLength(10).IsOptional();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.Title).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.Description).HasMaxLength(500).IsRequired();

            modelBuilder.Entity<ProductImage>().ToTable("ProductImage");
            modelBuilder.Entity<ProductImage>().Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<ProductImage>().Property(x => x.Title).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<ProductImage>().Property(x => x.Description).HasMaxLength(500).IsRequired();

            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().Property(x => x.FullName).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.Email).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.ShipAddress).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.Phone).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<ApplicationUser>().Property(x => x.FullName).HasMaxLength(200).IsRequired();

            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Order>().Property(x => x.TotalPrice).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.Status).IsRequired();
            modelBuilder.Entity<Order>().HasMany(s => s.OrderItems).WithRequired(c => c.Order);
            modelBuilder.Entity<Order>().HasRequired<Customer>(s => s.Customer).WithMany(g => g.Orders);

            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
            modelBuilder.Entity<OrderItem>().Property(x => x.Amount).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<OrderItem>().HasRequired<Order>(c => c.Order).WithMany(c => c.OrderItems);
        }
    }
}