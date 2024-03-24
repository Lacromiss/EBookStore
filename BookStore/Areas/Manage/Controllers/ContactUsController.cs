using Core.Entities;
using Core.Repositories.Interfaces;
using DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace BookStore.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]

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
                ModelState.AddModelError("ContactUs", "Bos kecdiyin hisse var. her seyi elave etdiyinden emin ol");
                return View();
            }
          await  _contactService.CreateAsync(contactUs);
            return RedirectToAction(nameof(Index));
        }

 



        
    }
}
