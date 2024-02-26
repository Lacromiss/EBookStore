using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
