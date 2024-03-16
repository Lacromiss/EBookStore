using Core.Entities;
using DAL.Concrete;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Reflection.Metadata;

namespace BookStore.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly EBookStoreDbContext _context;

        public BlogController(IBlogService blogService, EBookStoreDbContext context)
        {
            _blogService = blogService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // IEnumerable<Blog> blog =  await _blogService.GetAllAsync();
      List<  Blog> blog=    _context.blogs.ToList();
            return View(blog);
        }
        public async Task< IActionResult> Create()
        {
            return  View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
                    }
         await  _blogService.CreateAsync(blog);

           
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var blog1 = await _blogService.GetByIdAsync(id);

            return View(blog1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Blog blog,int id)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

          await  _blogService.UpdateAsync(blog, id);
            return RedirectToAction(nameof(Index));
        }
    }
}
