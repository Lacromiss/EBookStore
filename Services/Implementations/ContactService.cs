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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;


        }
        public async Task CreateAsync(ContactUs contact)
        {
            contact.CreatedDate = DateTime.Now;
            await _contactRepository.AddAsync(contact);
        }

        public async Task<List<ContactUs>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<ContactUs> GetAsync(int id)
        {
            return await _contactRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ContactUs contact, int id)
        {
            ContactUs findedcontactUs = await _contactRepository.GetByIdAsync(id);
            findedcontactUs.Email = contact.Email;
            findedcontactUs.RememberMe = contact.RememberMe;
            findedcontactUs.Message = contact.Message;
            findedcontactUs.isDeleted = contact.isDeleted;
            findedcontactUs.Id = contact.Id;
            findedcontactUs.Name = contact.Name;
            findedcontactUs.PhoneNumber = contact.PhoneNumber;

            findedcontactUs.UpdatedDate = DateTime.Now;
            findedcontactUs.CreatedDate = contact.CreatedDate;
            await _contactRepository.UpdateAsync(findedcontactUs);

        }
    }
}
