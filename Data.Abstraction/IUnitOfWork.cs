using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Data.Abstraction
{
    public interface IUnitOfWork
    {
        public IRepository<Category> CategoryRepository { get; }

        public IRepository<DetailTemplate> DetailTemplateRepository { get; }

        public IRepository<Production> ProductionRepository { get; }

        public IRepository<Detail> DetailRepository { get; }
        
        UserManager<User> UserManager { get; }
        
        SignInManager<User> SignInManager { get; }

        Task<int> Save();
    }
}