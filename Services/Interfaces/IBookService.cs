using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBookService
    {
        public Task CreateAsync(Book book);
        public Task UpdateAsync(Book book,int id);
        public Task <Book> GetAsync(int id);
        public Task<List<Book>> GetAllAsync();
        public Task RemoveAasync(int id);

    }
}
