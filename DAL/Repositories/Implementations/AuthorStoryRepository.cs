using Core.Entities;
using DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class AuthorStoryRepository:GenericRepository<AuthorStoryRepository>
    {
        public AuthorStoryRepository(EBookStoreDbContext baseModel):base(baseModel)
        {
            
        }
    }
}
