using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Services.Exceptions;
using Services.Interfaces;
using Services.Utilites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Implementations
{
    public class BookService : IBookService
    {
       private  IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository=bookRepository;
            
        }

        public async void Create( Book book)
        {

           // book.ImgUrl = await book.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));

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

       

     
    

        public async   Task UpdateAsync(Book book1, int id)
        {

            Book book = await _bookRepository.GetByIdAsync(id);
           
          
           book.Description = book1.Description;
         book.Author = book1.Author;
            book.AuthorId = book1.AuthorId;
            book.ImgUrl = book1.ImgUrl;
            book.Raiting = book1.Raiting;
            book.isDeleted = book1.isDeleted;
            book.Lenght = book1.Lenght;
            book.Name = book1.Name;
            book.UpdatedDate = DateTime.Now;
            book.CreatedDate = book1.CreatedDate;
            book.isFeatured = book1.isFeatured;

           await _bookRepository.UpdateAsync(book);
            

        }

      
    }
}
