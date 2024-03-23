using Core.Entities;
using Core.Repositories.Interfaces;
using DAL.Concrete;
using DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Services.Implementations;
using Services.Interfaces;

namespace BookStore.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BookController : Controller
    {
          IBookService _bookService;
        private readonly EBookStoreDbContext _dbContext;

        public BookController(IBookService bookService, EBookStoreDbContext dbContext)
        {
            _bookService = bookService;
            _dbContext = dbContext;
        }

        public async Task< IActionResult> Index()
        {
          IEnumerable<Book> books =  await _bookService.GetAllAsync();
            return View(books); 
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            _bookService.Create(book);

            return RedirectToAction(nameof(Index));
        }
        public  async Task< IActionResult> Update(int id ) 
        {
           
            var book= await _bookService.GetAsync(id);
            return View(book);
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task< IActionResult> UpdateAsync(Book book,int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
                
            }

            await    _bookService.UpdateAsync(book,id);
            return RedirectToAction(nameof(Index));
        }
    }
}
