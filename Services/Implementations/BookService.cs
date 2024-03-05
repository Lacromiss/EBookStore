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
    public class BookService : IBookService
    {
       private readonly IGenericRepository<Book> _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository=bookRepository;
            
        }

        public void Create(Book book)
        {
            _bookRepository.AddAsync(book);
        }

        public Task< Book> Get(int id)
        {
            return _bookRepository.GetByIdAsync(id);
        }

        public Task<List<Book>> GetAllAsync()
        {
           return _bookRepository.GetAllAsync();

        }

        public void Update(Book book)
        {
           _bookRepository.UpdateAsync(book);
        }
    }
}
