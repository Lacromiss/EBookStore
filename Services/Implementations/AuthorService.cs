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
    public class AuthorService : IAuthorService
    {
     private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository=authorRepository;


        }
        public async Task CreateAsync(Author author)
        {
            author.CreatedDate = DateTime.Now;
         await  _authorRepository.AddAsync(author);
        }

        public async Task<List<Author>> GetAllAsync()
        {
           return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> GetByIdAasync(int id)
        {
          return await _authorRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Author author,int id)
        {
            Author updateAuthor = await _authorRepository.GetByIdAsync(id);
           updateAuthor.AuthorPhone = author.AuthorPhone;
            updateAuthor.AuthorEmail = author.AuthorEmail;
            updateAuthor.AuthorFullName = author.AuthorFullName;
            updateAuthor.AuthorDescription = author.AuthorDescription;
            updateAuthor.Blogs = author.Blogs;
            updateAuthor.Books = author.Books;
            updateAuthor.CreatedDate = author.CreatedDate;
            updateAuthor.Country = author.Country;
            updateAuthor.UpdatedDate = DateTime.Now;
            updateAuthor.Id = author.Id;
            updateAuthor.PublishedBook = author.PublishedBook;

           await _authorRepository.UpdateAsync(updateAuthor);
           

        }

      
    }
}
