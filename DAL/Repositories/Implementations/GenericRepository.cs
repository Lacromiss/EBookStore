using Core.Repositories.Interfaces;
using DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EBookStoreDbContext _context;
        public GenericRepository(EBookStoreDbContext context)
        {
            _context = _context;
        }

        public async Task AddAsync(T entity)
        {
            _context.Add(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToList();

        }

        public async Task<T> GetByIdAsync(int id)
        {
           return _context.Set<T>().Find(id);
        }

        public Task<int> SaveAsync(int id)
        {
          return  _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
        }
    }
}
