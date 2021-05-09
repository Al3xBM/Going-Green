using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormGenerator.Data
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public Repository(DataContext context)
        {
            _context = context;
        }

        public DataContext _context { get; }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(CreateAsync)} entity must not be null");
            }
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(CreateAsync)} could not be saved:{ex.Message}");
            }
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(DeleteAsync)} could not be deleted:{ex.Message}");
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {

                throw new Exception($"Couldn't retrive entities: {ex.Message}");

            }
        }

        public async Task<T> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(GetById)} id must not be empty");
            }
            try
            {
                return await _context.FindAsync<T>(id);
            }
            catch (Exception ex)
            {

                throw new Exception($"Couldn't retrive entity: {ex.Message}");
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(UpdateAsync)} could not be update:{ex.Message}");
            }
        }
    }
}
