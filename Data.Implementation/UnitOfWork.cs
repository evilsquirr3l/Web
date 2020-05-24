using System.Threading.Tasks;
using Data.Abstraction;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductionDbContext _context;

        public UnitOfWork(IRepository<Category> categoryRepository,
            IRepository<DetailTemplate> detailTemplateRepository, 
            IRepository<Production> productionRepository,
            IRepository<Detail> detailRepository, 
            ProductionDbContext context, 
            UserManager<User> userManager)
        {
            CategoryRepository = categoryRepository;
            DetailTemplateRepository = detailTemplateRepository;
            ProductionRepository = productionRepository;
            DetailRepository = detailRepository;
            _context = context;
            UserManager = userManager;
        }

        public IRepository<Category> CategoryRepository { get; }
        public IRepository<DetailTemplate> DetailTemplateRepository { get; }
        public IRepository<Production> ProductionRepository { get; }
        public IRepository<Detail> DetailRepository { get; }
        public UserManager<User> UserManager { get; }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}