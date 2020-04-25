using System.Threading.Tasks;
using Entities;

namespace Data.Interfaces
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