using Core.Entities;
using Core.Repositories.Interfaces;
using DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;

namespace BookStore.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       public IActionResult Create(Book book)
        {

            book.CreatedDate = DateTime.Now;
            book.isDeleted = true;

            _bookService.Create(book);

            return RedirectToAction(nameof(Index));
        }
    }
}
