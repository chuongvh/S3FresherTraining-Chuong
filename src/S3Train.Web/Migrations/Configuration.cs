using S3Train.Domain;

namespace S3Train.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var categories = new List<Category>
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    Name = "Category One",
                    Summary = "Lorem ipsum"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    Name = "Category Two",
                    Summary = "Lorem ipsum"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    Name = "Category Three",
                    Summary = "Lorem ipsum"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    Name = "Category Four",
                    Summary = "Lorem ipsum"
                },
            };
            categories.ForEach(x => context.Categories.AddOrUpdate(c => c.Name, x));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    CategoryId = categories.Single(x => x.Name.Equals("Category One", StringComparison.OrdinalIgnoreCase)).Id,
                    ImagePath = "http://placehold.it/700x400",
                    Name = "Product One",
                    Price = 24.99m,
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                    Rating = null
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    CategoryId = categories.Single(x => x.Name.Equals("Category One", StringComparison.OrdinalIgnoreCase)).Id,
                    ImagePath = "http://placehold.it/700x400",
                    Name = "Product Two",
                    Price = 13m,
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                    Rating = 5
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    CategoryId = categories.Single(x => x.Name.Equals("Category Two", StringComparison.OrdinalIgnoreCase)).Id,
                    ImagePath = "http://placehold.it/700x400",
                    Name = "Product Three",
                    Price = 33.15m,
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                    Rating = 1
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    CategoryId = categories.Single(x => x.Name.Equals("Category Two", StringComparison.OrdinalIgnoreCase)).Id,
                    ImagePath = "http://placehold.it/700x400",
                    Name = "Product Four",
                    Price = 16.27m,
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                    Rating = 3
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    CategoryId = categories.Single(x => x.Name.Equals("Category Three", StringComparison.OrdinalIgnoreCase)).Id,
                    ImagePath = "http://placehold.it/700x400",
                    Name = "Product Five",
                    Price = 10m,
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                    Rating = 4
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    CategoryId = categories.Single(x => x.Name.Equals("Category Three", StringComparison.OrdinalIgnoreCase)).Id,
                    ImagePath = "http://placehold.it/700x400",
                    Name = "Product Six",
                    Price = 18.02m,
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                    Rating = 4
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    CategoryId = categories.Single(x => x.Name.Equals("Category Four", StringComparison.OrdinalIgnoreCase)).Id,
                    ImagePath = "http://placehold.it/700x400",
                    Name = "Product Seven",
                    Price = 17.99m,
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                    Rating = 2
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    CategoryId = categories.Single(x => x.Name.Equals("Category Four", StringComparison.OrdinalIgnoreCase)).Id,
                    ImagePath = "http://placehold.it/700x400",
                    Name = "Product Eight",
                    Price = 21.35m,
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!",
                    Rating = 1
                },
            };
            products.ForEach(x => context.Products.AddOrUpdate(p => p.Name, x));
            context.SaveChanges();

            var productAds = new List<ProductAdvertisement>
            {
                new ProductAdvertisement
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    EventUrl = "controller/action/1",
                    EventUrlCaption = string.Empty,
                    ImagePath = "http://placehold.it/900x350",
                    Title = "Lorem ipsum",
                    Description = string.Empty,
                    AdType = ProductAdvertisementType.SliderBanner
                },
                new ProductAdvertisement
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    EventUrl = "controller/action/2",
                    EventUrlCaption = string.Empty,
                    ImagePath = "http://placehold.it/900x350",
                    Title = "Lorem ipsum",
                    Description = string.Empty,
                    AdType = ProductAdvertisementType.SliderBanner
                },
                new ProductAdvertisement
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    EventUrl = "controller/action/3",
                    EventUrlCaption = string.Empty,
                    ImagePath = "http://placehold.it/900x350",
                    Title = "Lorem ipsum",
                    Description = string.Empty,
                    AdType = ProductAdvertisementType.SliderBanner
                },
                new ProductAdvertisement
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    EventUrl = "controller/action/1",
                    EventUrlCaption = string.Empty,
                    ImagePath = "http://placehold.it/900x350",
                    Title = "Lorem ipsum",
                    Description = string.Empty,
                    AdType = ProductAdvertisementType.MidHorRectangleBanner
                },
                new ProductAdvertisement
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    IsActive = true,

                    EventUrl = "controller/action/1",
                    EventUrlCaption = string.Empty,
                    ImagePath = "http://placehold.it/900x350",
                    Title = "Lorem ipsum",
                    Description = string.Empty,
                    AdType = ProductAdvertisementType.MidHorRectangleBanner
                },
            };
            productAds.ForEach(x => context.ProductAdvertisements.AddOrUpdate(p => p.Title, x));
            context.SaveChanges();
        }
    }
}
