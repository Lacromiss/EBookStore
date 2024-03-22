using Core.ViewModel;
using DAL.Concrete;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class AboutController : Controller
    {
        private readonly EBookStoreDbContext _context;

        public AboutController(EBookStoreDbContext context)
        {
            _context=context;


        }
        public IActionResult Index()
        {
            AboutViewModel layoutView = new AboutViewModel
            {
                Blogs=_context.blogs.ToList(),
                AuthorSkills=_context.authorSkills.ToList(),
                AuthorStory=_context.authorStories.ToList(), 
            };

            return View(layoutView);
        }
    }
}
