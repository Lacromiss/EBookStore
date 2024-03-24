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
            return await _blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogRepository.GetByIdAsync(id);

        }

        public async Task UpdateAsync(Blog blog, int id)
        {
            Blog blog1 = await _blogRepository.GetByIdAsync(id);
            blog1.Title = blog.Title;
            blog1.Description = blog.Description;
            blog1.Author = blog.Author;
            blog1.AuthorId = blog1.AuthorId;
            blog1.ImgUrl = blog.ImgUrl;
            blog1.isDeleted = blog.isDeleted;
            blog1.UpdatedDate = DateTime.Now;
            blog1.CreatedDate = blog.CreatedDate;

            blog1.Link = blog.Link;
            blog1.isFeatured = blog.isFeatured;


            await _blogRepository.UpdateAsync(blog1);


        }
        public async Task RemoveAasync(int id)
        {
            Blog blog = await _blogRepository.GetByIdAsync(id);
            if (blog != null)
            {
                await _blogRepository.RemoveAsync(blog);
            }
        }

    }
}
