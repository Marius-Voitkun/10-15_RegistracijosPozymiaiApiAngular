using Microsoft.EntityFrameworkCore;
using RegistracijosPozymiaiWebApi.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistracijosPozymiaiWebApi.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        // string includeProperties - properties, separated with ','
        public virtual async Task<List<T>> GetAllAsync(string includeProperties)
        {
            return await IncludeProperties(_dbSet, includeProperties).ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // string includeProperties - properties, separated with ','
        public virtual async Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> predicate, string includeProperties)
        {
            return await IncludeProperties(_dbSet.Where(predicate), includeProperties).ToListAsync();
        }

        public virtual async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        private IQueryable<T> IncludeProperties(IQueryable<T> query, string properties)
        {
            if (!string.IsNullOrWhiteSpace(properties))
            {
                foreach (var property in properties.Split(',', StringSplitOptions.TrimEntries))
                {
                    query = query.Include(property);
                }
            }

            return query;
        }
    }
}
