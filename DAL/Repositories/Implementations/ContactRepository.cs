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
    public class ContactRepository:GenericRepository<ContactUs>,IContactRepository
    {
        public ContactRepository(EBookStoreDbContext context):base(context) { }
        
    }
}
