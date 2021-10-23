using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistracijosPozymiaiWebApi.DAL.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(string includeProperties);
        Task<T> GetAsync(int id);
        Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> predicate, string includeProperties);
        Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
