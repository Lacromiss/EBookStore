using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;

namespace BookStore.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService=authorService;
        }
        public async Task<IActionResult> Index()
        {
      List<Author> authors=      await _authorService.GetAllAsync();

            return View(authors);
        }
        public async Task<IActionResult> Create() {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author) {

            if (!ModelState.IsValid)
            {
                return View();    
            }
         await   _authorService.CreateAsync(author);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
    Author updatedAuthor=       await _authorService.GetByIdAasync(id);


            return View(updatedAuthor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Author author,int id)
        {
            Author updatedAuthor = await _authorService.GetByIdAasync(id);
            if (!ModelState.IsValid) { return View(); }

           await _authorService.UpdateAsync(author, id);



            return RedirectToAction(nameof(Index));
        }

    }
}
