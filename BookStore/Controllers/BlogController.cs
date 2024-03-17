using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;

namespace BookStore.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService= blogService;


        }

        public async Task<IActionResult> Index()
        {
       List<Blog>blogs=   await _blogService.GetAllAsync();
            return View(blogs);
        }
    }
}
