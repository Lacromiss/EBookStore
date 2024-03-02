using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        public Task<T> GetByIdAsync(int id);
        public Task<T> GetAllAsync(T entity);
        public Task<T>Add(T entity);
        public Task<T> Update(T entity);
        public int Save(int id);
    }
}
