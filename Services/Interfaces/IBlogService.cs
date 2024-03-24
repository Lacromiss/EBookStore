using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBlogService
    {
        public Task CreateAsync(Blog blog);
        public Task UpdateAsync(Blog blog, int id);
        public  Task<Blog> GetByIdAsync(int id);
        public Task<List<Blog>> GetAllAsync();
        public Task RemoveAasync(int id);

    }
}
