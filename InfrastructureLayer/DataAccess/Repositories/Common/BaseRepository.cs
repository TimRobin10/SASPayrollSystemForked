using InfrastructureLayer.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace InfrastructureLayer.DataAccess.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private AppDbContext _db;

        public BaseRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var dbSet = context.Set<T>();
                    await dbSet.AddAsync(entity);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error in BaseRepository: AddAsync method", ex);
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var dbSet = context.Set<T>();
                    await dbSet.AddRangeAsync(entities);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error in BaseRepository: AddRangeAsync method", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string? includeProperties = null)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var dbSet = context.Set<T>();
                    IQueryable<T> query = dbSet;
                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }
                    if (!string.IsNullOrEmpty(includeProperties))
                    {
                        foreach (var property in includeProperties
                            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            query = query.Include(property);
                        }
                    }
                    return await query.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error in BaseRepository: GetAllAsync method", ex);
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var dbSet = context.Set<T>();
                    var query = dbSet.Where(filter);
                    if (!string.IsNullOrEmpty(includeProperties))
                    {
                        foreach (var property in includeProperties
                            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            query = query.Include(property);
                        }
                    }
                    return await query.FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error in BaseRepository: GetAsync method", ex);
            }
        }

        public async Task RemoveAsync(T entity)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var dbSet = context.Set<T>();
                    dbSet.Remove(entity);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error in BaseRepository: RemoveAsync method", ex); ;
            }
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var dbSet = context.Set<T>();
                    dbSet.RemoveRange(entities);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error in BaseRepository: RemoveRangeAsync method", ex);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var dbSet = context.Set<T>();
                    dbSet.Update(entity);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error in BaseRepository: UpdateAsync method", ex);
            }
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var dbSet = context.Set<T>();
                    dbSet.UpdateRange(entities);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error in BaseRepository: UpdateRangeAsync method", ex);
            }
        }
    }
}
