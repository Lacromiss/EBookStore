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
       private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository=bookRepository;
            
        }

        public void Create(Book book)
        {
            _bookRepository.AddAsync(book);
        }

        public Task< Book> GetAsync(int id)
        {
            return _bookRepository.GetByIdAsync(id);
        }

        public Task<List<Book>> GetAllAsync()
        {
           return _bookRepository.GetAllAsync();

        }

        public async void UpdateAsync(Book book,int id)
        {
            Book book1= await _bookRepository.GetByIdAsync(id);
            book.Description = book1.Description;
            book.Author = book1.Author;
            book.AuthorId= book1.AuthorId;
            book.ImgUrl = book1.ImgUrl;
            book.Raiting= book1.Raiting;
            book.isDeleted= book1.isDeleted;
            book.Lenght= book1.Lenght;
            book.Name= book1.Name;
            book.UpdatedDate=DateTime.Now;
            book.CreatedDate= book1.CreatedDate;

           _bookRepository.UpdateAsync(book);
        }
    }
}
