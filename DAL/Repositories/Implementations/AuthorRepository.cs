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
    public class AuthorRepository:GenericRepository<Author>,IAuthorRepository
    {
        EBookStoreDbContext _context1;
        public AuthorRepository(EBookStoreDbContext context,EBookStoreDbContext context1):base(context)
        {

        }
    



    }
}
