using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthorService
    {
        public Task CreateAsync(Author author);
        public Task UpdateAsync(Author author,int id);
        public Task<List<Author>> GetAllAsync( );
        public  Task<Author> GetByIdAasync( int id);
    }
}
