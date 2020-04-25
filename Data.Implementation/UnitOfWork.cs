using System.Threading.Tasks;
using Data.Interfaces;
using Entities;

namespace Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductionDbContext _context;

        public UnitOfWork(IRepository<Category> categoryRepository,
            IRepository<DetailTemplate> detailTemplateRepository, IRepository<Production> productionRepository,
            IRepository<Detail> detailRepository, ProductionDbContext context)
        {
            CategoryRepository = categoryRepository;
            DetailTemplateRepository = detailTemplateRepository;
            ProductionRepository = productionRepository;
            DetailRepository = detailRepository;
            _context = context;
        }

        public IRepository<Category> CategoryRepository { get; }
        public IRepository<DetailTemplate> DetailTemplateRepository { get; }
        public IRepository<Production> ProductionRepository { get; }
        public IRepository<Detail> DetailRepository { get; }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}