using S3Train.Domain;
namespace S3Train.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<S3Train.Domain.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(S3Train.Domain.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            var categories = new List<Category>
                {
                    new Category
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        Name = "Category One",
                        Description = "Lorem ipsum",
                        Status = "default"
                    },
                    new Category
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        Name = "Category Two",
                        Description = "Lorem ipsum",
                        Status = "default"
                    },
                    new Category
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        Name = "Category Three",
                        Description = "Lorem ipsum",
                        Status = "default"
                    },
                    new Category
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        Name = "Category Four",
                        Description = "Lorem ipsum",
                        Status = "default"
                    },
                };
            categories.ForEach(x => context.Categories.AddOrUpdate(c => c.Id, x));
            context.SaveChanges();

            var products = new List<Product>
                {
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    
                        //CategoryId = categories.Single(x => x.Name.Equals("Category One", StringComparison.OrdinalIgnoreCase)).Id,
                        //ImagePath = "http://placehold.it/700x400",
                        Name = "Product One",
                        Price = 24.99m,
                        Amount = 10,
                        SKU = "SKU",
                        Status = "default",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                        Rating = null
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        //CategoryId = categories.Single(x => x.Name.Equals("Category One", StringComparison.OrdinalIgnoreCase)).Id,
                        //ImagePath = "http://placehold.it/700x400",
                        Name = "Product Two",
                        Price = 13m,
                        Amount = 10,
                        SKU = "SKU",
                        Status = "default",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                        Rating = 5
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        //CategoryId = categories.Single(x => x.Name.Equals("Category Two", StringComparison.OrdinalIgnoreCase)).Id,
                        //ProductImagesId = "http://placehold.it/700x400"
                        Name = "Product Three",
                        Price = 33.15m,
                        Amount = 10,
                        SKU = "SKU",
                        Status = "default",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                        Rating = 1
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        //CategoryId = categories.Single(x => x.Name.Equals("Category Two", StringComparison.OrdinalIgnoreCase)).Id,
                        //ImagePath = "http://placehold.it/700x400",
                        Name = "Product Four",
                        Price = 16.27m,
                        Amount = 10,
                        SKU = "SKU",
                        Status = "default",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                        Rating = 3
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        //CategoryId = categories.Single(x => x.Name.Equals("Category Three", StringComparison.OrdinalIgnoreCase)).Id,
                        //ImagePath = "http://placehold.it/700x400",
                        Name = "Product Five",
                        Price = 10m,
                        Amount = 10,
                        SKU = "SKU",
                        Status = "default",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                        Rating = 4
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        //CategoryId = categories.Single(x => x.Name.Equals("Category Three", StringComparison.OrdinalIgnoreCase)).Id,
                        //ImagePath = "http://placehold.it/700x400",
                        Name = "Product Six",
                        Price = 18.02m,
                        Amount = 10,
                        SKU = "SKU",
                        Status = "default",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                        Rating = 4
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        //CategoryId = categories.Single(x => x.Name.Equals("Category Four", StringComparison.OrdinalIgnoreCase)).Id,
                        //ImagePath = "http://placehold.it/700x400",
                        Name = "Product Seven",
                        Price = 17.99m,
                        Amount = 10,
                        SKU = "SKU",
                        Status = "default",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                        Rating = 2
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        //CategoryId = categories.Single(x => x.Name.Equals("Category Four", StringComparison.OrdinalIgnoreCase)).Id,
                        //ImagePath = "http://placehold.it/700x400",
                        Name = "Product Eight",
                        Price = 21.35m,
                        Amount = 10,
                        SKU = "SKU",
                        Status = "default",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                        Rating = 1
                    },
                };
            products.ForEach(x => context.Products.AddOrUpdate(p => p.Id, x));
            context.SaveChanges();

            var productAds = new List<ProductAdvertisement>
                {
                    new ProductAdvertisement
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        EventUrl = "controller/action/1",
                        EventUrlCaption = string.Empty,
                        ImagePath = "http://placehold.it/900x350",
                        Title = "Adver One",
                        Description = "Lorem ipsum",
                        AdType = ProductAdvertisementType.SliderBanner
                    },
                    new ProductAdvertisement
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        EventUrl = "controller/action/2",
                        EventUrlCaption = string.Empty,
                        ImagePath = "http://placehold.it/900x350",
                        Title = "Adver Two",
                        Description = "Lorem ipsum",
                        AdType = ProductAdvertisementType.SliderBanner
                    },
                    new ProductAdvertisement
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        EventUrl = "controller/action/3",
                        EventUrlCaption = string.Empty,
                        ImagePath = "http://placehold.it/900x350",
                        Title = "Adver Three",
                        Description = "Lorem ipsum",
                        AdType = ProductAdvertisementType.SliderBanner
                    },
                    new ProductAdvertisement
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        EventUrl = "controller/action/1",
                        EventUrlCaption = string.Empty,
                        ImagePath = "http://placehold.it/900x350",
                        Title = "Adver Four",
                        Description = "Lorem ipsum",
                        AdType = ProductAdvertisementType.MidHorRectangleBanner
                    },
                    new ProductAdvertisement
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        EventUrl = "controller/action/1",
                        EventUrlCaption = string.Empty,
                        ImagePath = "http://placehold.it/900x350",
                        Title = "Adver Five",
                        Description = "Lorem ipsum",
                        AdType = ProductAdvertisementType.MidHorRectangleBanner
                    },
                };
            productAds.ForEach(x => context.ProductAdvertisements.AddOrUpdate(p => p.Id, x));
            context.SaveChanges();

            var productImages = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        ImagePath = "http://placehold.it/900x350",
                        ProductId = products.Single(x => x.Name.Equals("Product One", StringComparison.OrdinalIgnoreCase)).Id,   
                        Title = "Image One",
                        Description = "Lorem ipsum",
                    },
                    new ProductImage
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        ImagePath = "http://placehold.it/900x350",
                        ProductId = products.Single(x => x.Name.Equals("Product Two", StringComparison.OrdinalIgnoreCase)).Id,
                        Title = "Image Two",
                        Description = "Lorem ipsum",
                    },
                    new ProductImage
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        ImagePath = "http://placehold.it/900x350",
                        ProductId = products.Single(x => x.Name.Equals("Product Three", StringComparison.OrdinalIgnoreCase)).Id,
                        Title = "Image Three",
                        Description = "Lorem ipsum",
                    },
                    new ProductImage
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedDate = DateTime.Now,
                        IsActive = true,

                        ImagePath = "http://placehold.it/900x350",
                        ProductId = products.Single(x => x.Name.Equals("Product Four", StringComparison.OrdinalIgnoreCase)).Id,
                        Title = "Image Four",
                        Description = "Lorem ipsum",
                    },

                };
            productImages.ForEach(x => context.ProductImages.AddOrUpdate(p => p.Id, x));
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    FullName = "Customer One",
                    Email = "Email One",
                    Phone = "Phone",
                    ShipAddress = "Address",  
                },
                new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    FullName = "Customer Two",
                    Email = "Email Two",
                    Phone = "Phone",
                    ShipAddress = "Address",
                },
                new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    FullName = "Customer Three",
                    Email = "Email Three",
                    Phone = "Phone",
                    ShipAddress = "Address",
                },
            };

            customers.ForEach(x => context.Customers.AddOrUpdate(p => p.Id, x));
            context.SaveChanges();
/*
            var Users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),

                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),

                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),

                },
            };
            Users.ForEach(x => context.Users.AddOrUpdate(p => p.FullName, x));
            context.SaveChanges();

            var Orders = new List<Order>
            {
                new Order
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                },
            };
            Orders.ForEach(x => context.Orders.AddOrUpdate(p => p.Id, x));
            context.SaveChanges();

            var OrderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                },
            };
            OrderItems.ForEach(x => context.OrderItems.AddOrUpdate(p => p.Id, x));
            context.SaveChanges();  */
        }
    }
}
