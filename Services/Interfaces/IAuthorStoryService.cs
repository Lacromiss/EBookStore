using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthorStoryService
    {
        public Task CreateAsync(AuthorStory authorStory);
        public Task UpdateAsync(AuthorStory authorStory, int id);
        public Task<List<AuthorStory>> GetAllAsync();
        public Task<AuthorStory> GetByIdAasync(int id);
    }
}
