using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IContactService
    {
        public Task CreateAsync(ContactUs contact);
        public Task UpdateAsync(ContactUs contact, int id);
        public Task<ContactUs> GetAsync(int id);
        public Task<List<ContactUs>> GetAllAsync();
    }
}
