using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IBookRepository _bookRepository;
        private readonly IWebHostEnvironment _env;

        public BookService(IBookRepository bookRepository, IWebHostEnvironment env)
        {
            _bookRepository = bookRepository;
            _env=env;

        }

        public async Task CreateAsync(Book book)
        {

            try
            {
                if (book.Photo != null)
                {


                    if (!book.Photo.CheckType("image/"))
                    {
                        throw new ImgValidationExcemtions("img formatinda bir seyler at");

                    }
                    if (!book.Photo.CheckSize(5))
                    {
                        throw new ImgValidationExcemtions("maks 5mbfayl yukelye bilersen");

                    }
                    book.ImgUrl = await book.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Assests", "assets", "img"));
                }

            }
            catch (ImgValidationExcemtions)
            {

                throw;
            }
            book.CreatedDate = DateTime.Now;
          await  _bookRepository.AddAsync(book);
        }

        public Task<Book> GetAsync(int id)
        {
            return _bookRepository.GetByIdAsync(id);
        }

        public Task<List<Book>> GetAllAsync()
        {
            return _bookRepository.GetAllAsync();

        }






        public async Task UpdateAsync(Book book1, int id)
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

        public async Task RemoveAasync(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
            {
              await  _bookRepository.RemoveAsync(book);
            }
        }
    }
}
