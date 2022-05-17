using CinemaPlatform.DAL.Interfaces;
using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaPlatform.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly CinemaDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        private IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression is not null ? _dbSet.Where(expression) : _dbSet;
        }

        public EntityState Add(TEntity entity)
        {
            return _dbSet.Add(entity).State;
        }

        public IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>>? expression = null)
        {
            return Query(expression);
        }

        public IQueryable<TEntity> GetByIdAsync(int entityId)
        {
            return Query(x => x.Id == entityId);
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                foreach (var e in ex.Entries)
                {
                    switch (e.State)
                    {
                        case EntityState.Added:
                            e.State = EntityState.Detached;
                            break;
                        case EntityState.Modified:
                            e.CurrentValues.SetValues(e.OriginalValues);
                            e.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            e.State = EntityState.Unchanged;
                            break;
                    }
                }
            }
        }

        public EntityState Update(TEntity entity)
        {
            return _dbSet.Update(entity).State;
        }

        public async Task<EntityState> RemoveAsync(int entityId)
        {
            var entity = await GetByIdAsync(entityId).FirstOrDefaultAsync();

            return entity is not null ? _dbSet.Remove(entity).State : EntityState.Unchanged;
        }
    }
}
