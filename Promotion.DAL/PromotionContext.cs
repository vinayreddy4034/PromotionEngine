using Microsoft.EntityFrameworkCore;
using System;
using Promotion.Model;

namespace Promotion.DAL
{
    public class PromotionContext : DbContext
    {
        public PromotionContext(DbContextOptions<PromotionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOffer>().HasKey(e => new { e.ProductId, e.PromotionId });
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = "A", Price = 50 },
                new Product { Id = "B", Price = 30 },
                new Product { Id = "C", Price = 20 },
                new Product { Id = "D", Price = 15 });

            modelBuilder.Entity<Model.Promotion>().HasData(
                new Model.Promotion { Id = 1, Name = "But 3 A for 130", PromotionAmount = 130, Type = PromotionType.FixedPrice },
                 new Model.Promotion { Id = 2, Name = "But C and D for 30", PromotionAmount = 30, Type = PromotionType.FixedPrice });

            modelBuilder.Entity<ProductOffer>().HasData(new ProductOffer {Id=1, ProductId = "A", PromotionId = 1, Quantity = 3 });

            modelBuilder.Entity<ProductOffer>().HasData(new ProductOffer {Id=2, ProductId = "C", PromotionId = 2, Quantity = 1 });
            modelBuilder.Entity<ProductOffer>().HasData(new ProductOffer {Id=3, ProductId = "D", PromotionId = 2, Quantity = 1 });
            

        }
        public DbSet<Promotion.Model.Promotion> Promotions { get; set; }
        public DbSet<Promotion.Model.Product> Products { get; set; }


    }
}
