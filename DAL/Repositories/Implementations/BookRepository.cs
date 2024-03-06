using Core.Entities;
using Core.Repositories.Interfaces;
using DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class BookRepository:GenericRepository<Book>, IBookRepository
    {
        public BookRepository(EBookStoreDbContext context):base(context) 
        {
            
        }
    }
}
