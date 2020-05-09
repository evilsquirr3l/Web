using System.Linq;
using System.Threading.Tasks;
using Data.Abstraction;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ProductionDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var tEntity = await _dbSet.FindAsync(id);

            if (tEntity != null)
            {
                _dbSet.Remove(tEntity);
            }
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}