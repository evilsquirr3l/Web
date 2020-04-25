using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Data.Abstraction
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}