using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private DbSet<TEntity> _dbSet;

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

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}