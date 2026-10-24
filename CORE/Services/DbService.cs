using CORE.Domain;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace CORE.Services

{
    public abstract class DbService<TEntity> : Service, IDisposable where TEntity : Record, new()
    {
        private readonly DbContext _db;

        protected DbService(DbContext db){
            _db = db;
        }


        protected virtual IQueryable<TEntity> DbQuery()
        => _db.Set<Entity>().AsNoTracking();

        protected async Task<TEntity> DbSingleAsync(int id, CancellationToken cancellationToken = default)
        {
            return await DbQuery().AsTracking().SingleOrDefaultAsync(entity => entity.Id ==id, cancellationToken);
        }

        protected async Task<TEntity> DbSingleAsync(
            Expression<Func<TEntity, bool>> predicate, 
            CancellationToken cancellationToken = default)=>
            await DbQuery().AsTracking().SingleOrDefaultAsync(predicate, cancellationToken);

        protected virtual async Task<int> DbSaveAsync(
            CancellationToken cancellationToken = default)=>
            await _db.SaveChangesAsync(cancellationToken);

        protected async Task DbAddAsync(TEntity entity, 
        CancellationToken cancellationToken,
        bool save = true)
        {
            _db.Set<TEntity>().Add(entity);
            if(save)
                await DbSaveAsync(cancellationToken);
        }
        
        protected async Task DbUpdateAsync(TEntity entity, 
        CancellationToken cancellationToken,
        bool save = true)
        {
            _db.Set<TEntity>().Update(entity);
            if(save)
                await DbSaveAsync(cancellationToken);
        }
    }
}