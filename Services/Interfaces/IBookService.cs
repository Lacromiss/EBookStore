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
        public void Create(Book book);
        public void Update(Book book,int id);
        public Task <Book> Get(int id);
        public Task<List<Book>> GetAllAsync();
    }
}
