using Core.Entities;
using Core.Repositories.Interfaces;
using DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace BookStore.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ContactUsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactUsController(IContactService contactService)
        {
            _contactService = contactService;


        }
        public async Task<IActionResult> Index()
        {

            List<ContactUs> contactUs = await _contactService.GetAllAsync();
            return View(contactUs);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactUs contactUs)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
          await  _contactService.CreateAsync(contactUs);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int Id)
        {
            ContactUs contact= await _contactService.GetAsync(Id);
            
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ContactUs contactUs,int id)
        {
            ContactUs contact = await _contactService.GetAsync(id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _contactService.UpdateAsync(contactUs, id);

            return RedirectToAction(nameof(Index));
        }
    }
}
