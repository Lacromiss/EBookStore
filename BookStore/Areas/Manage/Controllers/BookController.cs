using Core.Entities;
using DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;

namespace BookStore.Areas.Manage.Controllers
{
    public class BookController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            
            return View();
        }
        public IActionResult Create(BookService bookService)
        {

            return View();
        }
    }
}
