using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Abstraction
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task DeleteByIdAsync(int id);

        void Update(TEntity entity);
    }
}