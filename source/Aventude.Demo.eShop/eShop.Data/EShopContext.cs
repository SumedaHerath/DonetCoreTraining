using Aventude.Demo.eShop.Data.Configurations;
using Aventude.Demo.eShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Aventude.Demo.eShop.Data
{
    public class EShopContext : DbContext
    {
        public EShopContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CatalogTypeConfigurations());
            modelBuilder.ApplyConfiguration(new CatalogBrandConfigurations());
            modelBuilder.ApplyConfiguration(new CatalogItemConfigurations());

            //SeeData(modelBuilder);
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }

        public DbSet<CompactCatalogItem> CompactCatalogItems { get; set; }

        private void SeeData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogItem>().HasData(
                new CatalogItem
                {
                    Id = 1,
                    Name = "Imorich Ice Cream(Chocalate)",
                    Description = "Imorich Ice Cream(Chocalate)",
                    Price = 720.00m,
                    ImageUrl = "",
                    ReorderLevel = 20,
                    CreatedBy = "Sumeda",
                    CreatedOn = DateTime.UtcNow
                }, 
                new CatalogItem
                {
                    Id = 2,
                    Name = "Imorich Ice Cream(Chocalate)",
                    Description = "Imorich Ice Cream(Chocalate)",
                    Price = 720.00m,
                    ImageUrl = "",
                    ReorderLevel = 20,
                    CreatedBy = "Sumeda",
                    CreatedOn = DateTime.UtcNow
                });
        }
    }
}
