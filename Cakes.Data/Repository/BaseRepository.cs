using Cakes.Data.Context;
using Cakes.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cakes.Data.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        private readonly DataContext _DbContext;

        protected BaseRepository(DataContext dbContext)
        {
            _DbContext = dbContext;
            DbSet = _DbContext.Set<TEntity>();
        }


        public virtual async Task<Pagination> GetAll
        (
            bool asNoTracking = true,
            int skip = 0,
            int take = 20
        )
        {
            var databaseCount = await DbSet.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Pagination
                {
                    Take = take,
                    Skip = skip,
                    Data = await DbSet.AsNoTracking().Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                    Total = databaseCount
                };

            return new Pagination
            {
                Take = take,
                Skip = skip,
                Data = await DbSet.Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                Total = databaseCount
            };
        }

        public virtual async Task<Pagination> GetAllSelect<BEntity>
        (
            Expression<Func<TEntity, BEntity>> select,
            bool asNoTracking = true,
            int skip = 0,
            int take = 20
        ) where BEntity : class
        {
            var databaseCount = await DbSet.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Pagination
                {
                    Take = take,
                    Skip = skip,
                    Data = await DbSet.AsNoTracking().Select(select).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                    Total = databaseCount
                };

            return new Pagination
            {
                Take = take,
                Skip = skip,
                Data = await DbSet.Select(select).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                Total = databaseCount
            };
        }


        public virtual async Task<TEntity?> GetById
        (
            Guid entity
        )
        {
            return await DbSet.FindAsync(entity).ConfigureAwait(false);
        }

        public virtual async Task<TEntity?> FirstOrDefault
        (
            Expression<Func<TEntity, bool>> where,
            bool asNoTracking = true
        )
        {
            if (asNoTracking)
                return await DbSet.AsNoTracking().FirstOrDefaultAsync(where).ConfigureAwait(false);


            return await DbSet.FirstOrDefaultAsync(where).ConfigureAwait(false);
        }


        public virtual async Task<Pagination> GetAll
        (
            Expression<Func<TEntity, bool>> where,
            bool asNoTracking = true,
            int skip = 0,
            int take = 20
        )
        {
            var databaseCount = await DbSet.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Pagination
                {
                    Take = take,
                    Skip = skip,
                    Data = await DbSet.AsNoTracking().Where(where).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                    Total = databaseCount
                };


            return new Pagination
            {
                Take = take,
                Skip = skip,
                Data = await DbSet.Where(where).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                Total = databaseCount
            };
        }


        public virtual async Task<Pagination> GetAll
        (
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, object>> orderBy,
            bool asNoTracking = true,
            int skip = 0,
            int take = 20
        )
        {
            var databaseCount = await DbSet.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Pagination
                {
                    Take = take,
                    Skip = skip,
                    Data = await DbSet.AsNoTracking().OrderBy(orderBy).Where(where).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                    Total = databaseCount
                };



            return new Pagination
            {
                Take = take,
                Skip = skip,
                Data = await DbSet.OrderBy(orderBy).Where(where).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                Total = databaseCount
            };
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public virtual async Task AddCollectionAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities).ConfigureAwait(false);
        }

        public virtual IEnumerable<TEntity> AddCollectionWithProxy(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Add(entity);
                yield return entity;
            }
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateCollectionAsync(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }


        public virtual IEnumerable<TEntity> UpdateCollectionWithProxy(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Update(entity);
                yield return entity;
            }
        }

        public virtual Task RemoveByAsync(Func<TEntity, bool> where)
        {
            DbSet.RemoveRange(DbSet.ToList().Where(where));
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task SaveChangesAsync()
        {
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
