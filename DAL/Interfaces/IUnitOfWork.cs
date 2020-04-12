using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Category> CategoryRepository { get; }

        public IRepository<DetailTemplate> DetailTemplateRepository { get; }

        public IRepository<Production> ProductionRepository { get; }

        public IRepository<Detail> DetailRepository { get; }

        Task<int> Save();
    }
}