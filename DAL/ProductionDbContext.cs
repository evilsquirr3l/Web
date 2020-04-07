using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductionDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<DetailTemplate> DetailTemplates { get; set; }

        public DbSet<Production> Productions { get; set; }

        public DbSet<Radiodetail> Radiodetails { get; set; }

        public ProductionDbContext(DbContextOptions<ProductionDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}