using Catalog.Api.Data.Entities;
using Catalog.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Catalog.Api.Data
{
    public class CatalogContext : DbContext, ICatalogContext
    {
        private readonly IConfiguration _configuration;

        public CatalogContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<ProductDto> Products { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(_configuration.GetConnectionString(Constants.ConnectionStringKey));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDto>().HasData(
                new CategoryDto
                {
                    Id = 1,
                    Name = "Mobile Phones",
                    CreatedTimestamp = DateTime.Now,
                    UpdatedTimestamp = DateTime.Now
                },
                new CategoryDto
                {
                    Id = 2,
                    Name = "Audio Visual",
                    CreatedTimestamp = DateTime.Now,
                    UpdatedTimestamp = DateTime.Now
                },
                new CategoryDto
                {
                    Id = 3,
                    Name = "Clothing",
                    CreatedTimestamp = DateTime.Now,
                    UpdatedTimestamp = DateTime.Now
                }
            );

            modelBuilder.Entity<ProductDto>().HasData(
                new ProductDto
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "iPhone 12",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Price = 899.99M,
                    Summary = "Latest iPhone 12 with Night Mode",
                    ImageFile = "product-1.png"
                },
                new ProductDto
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Panasonic 60 inch TV",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Price = 1999.99M,
                    Summary = "Big screen TV with Ultra HD",
                    ImageFile = "product-2.png"
                },
                new ProductDto
                {
                    Id = 3,
                    CategoryId = 3,
                    Name = "North Face Hoody",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Price = 49.99M,
                    Summary = "Extra warm fleece hoody",
                    ImageFile = "product-3.png"
                }
            );
        }
    }
}
