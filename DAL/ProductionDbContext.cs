using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
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
    }
}