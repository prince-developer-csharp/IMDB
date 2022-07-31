using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        T Update(T entity);
        Task<T> GetById(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> GetAll();
    }
}
