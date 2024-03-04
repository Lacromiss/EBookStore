using Core.Entities;
using Core.Repositories.Interfaces;
using DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;

namespace BookStore.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookService bookService ,Book book)
        {
            if (!ModelState.IsValid) { 
                return View();
            }
          book.CreatedDate = DateTime.Now;

            bookService.Create(book);

            return RedirectToAction(nameof(Index));
        }
    }
}
