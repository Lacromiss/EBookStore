using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public interface IRepository<T>
    {
        public Task AddAsync(T entity);
        public Task<List<T>> GetAllAsync(T entity);
        public Task<T> GetById(int Id);
        public void Update(T entity);
       // public Task Remove(T entity);
        public Task<int> SaveAsync();
        public int Save();
        public Task<bool> IsExsist(T entity);
    }
}
