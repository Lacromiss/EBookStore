using BookStore.Img_validations;
using Core.Entities;
using Core.Repositories.Interfaces;
using DAL.Concrete;
using DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Services.Exceptions;
using Services.Implementations;
using Services.Interfaces;

namespace BookStore.Areas.Manage.Controllers
{
    [Area("Manage")]
    // [Authorize(Roles = "Admin,SuperAdmin")]

    public class BookController : Controller
    {
        IBookService _bookService;
        private readonly EBookStoreDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public BookController(IBookService bookService, EBookStoreDbContext dbContext, IWebHostEnvironment env)
        {
            _bookService = bookService;
            _dbContext = dbContext;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Book> books = await _bookService.GetAllAsync();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {

            if (!ModelState.IsValid)
            {
                return View(book);
            }
            try
            {

                await _bookService.CreateAsync(book);
                return RedirectToAction(nameof(Index));


            }
            catch (ImgValidationExcemtions ex)
            {

                ViewBag.ErrorMessage = ex.Message;
            }

            return View();

        }
        public async Task<IActionResult> Update(int id)
        {

            var book = await _bookService.GetAsync(id);
            return View(book);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(Book book, int id)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            try
            {
                await _bookService.UpdateAsync(book, id);
                return RedirectToAction(nameof(Index));
            }
            catch (ImgValidationExcemtions ex)
            {

                ViewBag.updateError = ex.Message;
            }
            return View();

        }

        public async Task<IActionResult> Remove(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            try
            {
                await _bookService.RemoveAasync(id);


            }
            catch (ImgValidationExcemtions ex)
            {

                ViewBag.removedError = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
