using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormGenerator.Data
{
    public interface IRepository<T> where T : class, new()
    {
        Task<T> GetById(Guid id);
        IEnumerable<T> GetAll();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

    }
}
