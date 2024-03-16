using Core.Entities;
using Core.ViewModel;
using DAL.Concrete;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly EBookStoreDbContext _context;

        public HomeController(EBookStoreDbContext context)
        {
            _context=context;
        }

        public async Task<IActionResult> Index()
        {
            BookBlogAuthorCommentVM HomePageVM = new BookBlogAuthorCommentVM
            {
                Authors = _context.authors.ToList(),
                Blogs = _context.blogs.Where(x=>x.isFeatured==true).ToList(),
                Books = _context.books.Where(x => x.isFeatured == true).ToList(),
            };
            return View(HomePageVM);
        }




    }
}
