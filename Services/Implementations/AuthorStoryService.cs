using Core.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AuthorStoryService : IAuthorStoryService
    {
        private readonly IAuthorStoryService _authorStoryService;

        public AuthorStoryService(IAuthorStoryService authorStoryService)
        {
            _authorStoryService=authorStoryService;


        }
        public async Task CreateAsync(AuthorStory authorStory)
        {
            authorStory.CreatedDate = DateTime.Now;
           await _authorStoryService.CreateAsync(authorStory);
        }

        public async Task<List<AuthorStory>> GetAllAsync()
        {
            return await _authorStoryService.GetAllAsync();
        }

        public async Task<AuthorStory> GetByIdAasync(int id)
        {
            return await _authorStoryService.GetByIdAasync(id);
        }

        public async Task UpdateAsync(AuthorStory authorStory, int id)
        {
            authorStory.UpdatedDate = DateTime.Now;
           AuthorStory author=await _authorStoryService.GetByIdAasync(id);
            author.UpdatedDate = DateTime.Now;
            author.CreatedDate = authorStory.CreatedDate;
            author.Description = authorStory.Description;
            author.AuthorSkills = authorStory.AuthorSkills;
            author.isDeleted = authorStory.isDeleted;
            author.Title = authorStory.Title;
            
        

             await _authorStoryService.UpdateAsync(authorStory, id);

        }
      
    }
}
