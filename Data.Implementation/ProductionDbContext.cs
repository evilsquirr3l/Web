using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class ProductionDbContext : DbContext
    {
        public ProductionDbContext(DbContextOptions<ProductionDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<DetailTemplate> DetailTemplates { get; set; }

        public DbSet<Production> Productions { get; set; }

        public DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region SeedData

            var detail1 = new Detail
            {
                Id = 1,
                Name = "Detail 1",
                CreationTime = DateTime.Now.AddDays(-1),
                DetailTemplateId = 1
            };

            var detail2 = new Detail
            {
                Id = 2,
                Name = "Detail 2",
                CreationTime = DateTime.Now.AddDays(-2),
                DetailTemplateId = 1
            };

            var detailTemplate = new DetailTemplate
            {
                Id = 1,
                ProductionId = 1,
                OutputDetailId = 2
            };
            var production = new Production
            {
                Id = 1,
                CategoryId = 1,
                Name = "Production1"
            };

            var cat1 = new Category
            {
                Id = 1,
                Name = "Some category",
                Type = "Some type"
            };

            modelBuilder.Entity<Detail>().HasData(detail1, detail2);
            modelBuilder.Entity<DetailTemplate>().HasData(detailTemplate);
            modelBuilder.Entity<Production>().HasData(production);
            modelBuilder.Entity<Category>().HasData(cat1);

            #endregion
        }
    }
}