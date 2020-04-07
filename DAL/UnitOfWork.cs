using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductionDbContext _context;
        
        public UnitOfWork(IRepository<Category> categoryRepository, IRepository<DetailTemplate> detailTemplateRepository, IRepository<Production> productionRepository, IRepository<Radiodetail> radiodetailRepository, ProductionDbContext context)
        {
            CategoryRepository = categoryRepository;
            DetailTemplateRepository = detailTemplateRepository;
            ProductionRepository = productionRepository;
            RadiodetailRepository = radiodetailRepository;
            _context = context;
        }

        public IRepository<Category> CategoryRepository { get; }
        public IRepository<DetailTemplate> DetailTemplateRepository { get; }
        public IRepository<Production> ProductionRepository { get; }
        public IRepository<Radiodetail> RadiodetailRepository { get; }
        
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}