using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;

namespace BookStore.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactUsController(IContactService contactService)
        {
            _contactService= contactService;


        }
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactUs contactUs)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _contactService.CreateAsync(contactUs);
            return RedirectToAction(nameof(Index));
        }
    }
}
