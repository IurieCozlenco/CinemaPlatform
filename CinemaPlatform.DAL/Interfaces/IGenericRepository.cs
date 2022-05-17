using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaPlatform.DAL.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        EntityState Add(TEntity entity);
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>>? expression = null);
        IQueryable<TEntity> GetByIdAsync(int entityId);
        Task<EntityState> RemoveAsync(int entityId);
        Task SaveChangesAsync();
        EntityState Update(TEntity entity);
    }
}
