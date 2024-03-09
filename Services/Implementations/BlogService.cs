using Core.Entities;
using Core.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task CreateAsync(Blog blog)
        {
            blog.CreatedDate = DateTime.Now;

           await _blogRepository.AddAsync(blog);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
          return await  _blogRepository.GetAllAsync();
        }

        public  async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogRepository.GetByIdAsync(id);
           
        }

        public async Task UpdateAsync(Blog blog, int id)
        {
           
            
          
        }

      
    }
}
