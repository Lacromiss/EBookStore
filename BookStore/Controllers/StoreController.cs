using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;

namespace BookStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IBookService _bookService;

        public StoreController(IBookService bookService)
        {
            _bookService=bookService;
        }
        public async Task<IActionResult> Index()
        {
       List< Book> book=   await _bookService.GetAllAsync();
            return View(book);
        }
    }
}
